namespace BlazorBasics.DraggableGrid;

public partial class GridVisualization<TData> : IDisposable
{
    [Parameter] public GridLayout Layout { get; set; } = new();
    [Parameter] public RenderFragment<TData>? ChildContent { get; set; }
    [Parameter] public GridItem? SelectedItem { get; set; }
    [Parameter] public EventCallback<GridItem?> SelectedItemChanged { get; set; }
    [Parameter] public EventCallback<GridLayout> LayoutChanged { get; set; }
    [Parameter] public EventCallback<GridItem> OnItemRemoved { get; set; }
    [Parameter] public bool AllowDragAndDrop { get; set; } = true;
    [Parameter] public bool AllowKeyboardControls { get; set; } = false;
    [Parameter] public GridTheme Theme { get; set; } = GridTheme.Default;

    private DragState _dragState = new();
    private GridCollisionService _collisionService;
    private GridPlacementService _placementService;
    private GridStyleService _styleService;
    private DragService _dragService;
    private HashSet<(int, int)> _occupiedCells = new();

    protected override void OnParametersSet()
    {
        InitializeServices();
        UpdateOccupiedCells();
    }

    private void InitializeServices()
    {
        _collisionService = new GridCollisionService(Layout);
        _placementService = new GridPlacementService(Layout, _collisionService);
        _styleService = new GridStyleService(Layout, Theme);
        _dragService = new DragService(Layout);
    }

    private string GetGridStyle() => _styleService.GetGridStyle();

    private string GetThemeStyles()
    {
        return $"--grid-bg: {Theme.GridBackground}; " +
               $"--grid-border: {Theme.GridBorderColor}; " +
               $"--item-border: {Theme.ItemBorderColor}; " +
               $"--item-shadow: {Theme.ItemShadowColor}; " +
               $"--hover-shadow: {Theme.ItemHoverShadowColor}; " +
               $"--selected-color: {Theme.SelectedColor}; " +
               $"--selected-glow: {Theme.SelectedGlowColor}; " +
               $"--dragging-color: {Theme.DraggingColor}; " +
               $"--dragging-glow: {Theme.DraggingGlowColor}; " +
               $"--drop-area-color: {Theme.DropAreaColor}; " +
               $"--drop-area-bg: {Theme.DropAreaBackground}; " +
               $"--drop-area-glow: {Theme.DropAreaGlowColor}; " +
               $"--drop-area-light-glow: {Theme.DropAreaLightGlowColor};";
    }

    private string GetItemStyle(GridItem item)
    {
        bool isSelected = SelectedItem?.Id == item.Id;
        bool isDragging = _dragState.DraggingItem?.Id == item.Id;
        return _styleService.GetItemStyle(item, isSelected, isDragging);
    }

    private async Task StartMouseDown(MouseEventArgs e, GridItem item)
    {
        _dragState.DraggingItem = item;
        if (!AllowDragAndDrop)
            return;
        _dragState.IsDragging = false;
        _dragState.DragMoved = false;

        (int x, int y) start = ((int)e.ClientX, (int)e.ClientY);
        _dragState.DragStartMouse = start;
        _dragState.DragCurrentMouse = start;
        _dragState.DragStartCell = (item.Column, item.Row);
        _dragState.DragCursorClass = "dragging";
    }

    private async Task HandleMouseMove(MouseEventArgs e)
    {
        if (_dragState.DraggingItem == null)
            return;

        (int x, int y) current = ((int)e.ClientX, (int)e.ClientY);
        _dragState.DragCurrentMouse = current;

        int deltaX = Math.Abs(current.x - _dragState.DragStartMouse?.ClientX ?? 0);
        int deltaY = Math.Abs(current.y - _dragState.DragStartMouse?.ClientY ?? 0);

        bool movedEnough = deltaX > 3 || deltaY > 3;

        if (movedEnough)
        {
            _dragState.DragMoved = true;
            _dragState.IsDragging = true;

            GridItem draggingItem = _dragState.DraggingItem;
            _dragState.FinalDropTarget = _dragService.CalculateDragTarget(e, _dragState, draggingItem);

            if (_dragState.FinalDropTarget.HasValue)
            {
                (int col, int row) = _dragState.FinalDropTarget.Value;
                _dragState.HoverTarget = (col, row);
                await InvokeAsync(StateHasChanged);
            }
        }
    }

    private async Task HandleMouseUp(MouseEventArgs e)
    {
        if (_dragState.IsDragging && _dragState.DraggingItem is not null &&
            _dragState.FinalDropTarget.HasValue)
        {
            (int col, int row) target = _dragState.FinalDropTarget.Value;

            await _placementService.PlaceItemAsync(_dragState.DraggingItem, target.col, target.row);
            SelectedItem = null;
            await LayoutChanged.InvokeAsync(Layout);
        }
        else
        {
            if (_dragState.DragMoved == false && _dragState.DraggingItem is not null)
            {
                if (SelectedItem is not null && SelectedItem.Id == _dragState.DraggingItem.Id)
                    SelectedItem = null;
                else
                    SelectedItem = _dragState.DraggingItem;

                await SelectedItemChanged.InvokeAsync(SelectedItem);
            }
        }

        await CleanUpDrag();
    }


    private async Task CleanUpDrag()
    {
        _dragState.Reset();
        await InvokeAsync(StateHasChanged);
    }

    private async Task CellClicked(int col, int row)
    {
        if (_dragState.IsDragging)
            return;

        // Si no hay item, mover el seleccionado si existe
        if (SelectedItem is not null)
        {
            await MoveSelectedItem(col, row);
        }
    }

    private async Task MoveSelectedItem(int targetCol, int targetRow)
    {
        if (SelectedItem is null)
            return;

        await _placementService.PlaceItemAsync(SelectedItem, targetCol, targetRow);
        await LayoutChanged.InvokeAsync(Layout);
        await InvokeAsync(StateHasChanged);
    }

    private async Task MoveSelectedItemByDelta(int deltaCol, int deltaRow)
    {
        if (SelectedItem is null)
            return;

        int newCol = SelectedItem.Column + deltaCol;
        int newRow = SelectedItem.Row + deltaRow;

        await MoveSelectedItem(newCol, newRow);
    }

    private async Task HandleKeyDown(KeyboardEventArgs e)
    {
        if (!AllowKeyboardControls)
            return;

        switch (e.Key)
        {
            case "ArrowUp":
                await MoveSelectedItemByDelta(0, -1);
                break;
            case "ArrowDown":
                await MoveSelectedItemByDelta(0, 1);
                break;
            case "ArrowLeft":
                await MoveSelectedItemByDelta(-1, 0);
                break;
            case "ArrowRight":
                await MoveSelectedItemByDelta(1, 0);
                break;
            case "Delete":
            case "Backspace":
                if (SelectedItem is not null)
                {
                    await OnItemRemoved.InvokeAsync(SelectedItem);
                }
                break;
            case "Escape":
                await SelectedItemChanged.InvokeAsync(null);
                break;
            case " ":
                if (SelectedItem is not null)
                {
                    await SelectedItemChanged.InvokeAsync(null);
                }
                else if (Layout.Items.Any())
                {
                    await SelectedItemChanged.InvokeAsync(Layout.Items.First());
                }
                break;
        }
    }

    private void UpdateOccupiedCells()
    {
        _occupiedCells.Clear();
        foreach (var item in Layout.Items)
        {
            var cells = _collisionService.GetItemCells(item);
            _occupiedCells.UnionWith(cells);
        }
    }

    // Métodos públicos para que el padre pueda controlar el grid
    public async Task MoveItem(int col, int row)
    {
        if (SelectedItem is null)
            return;
        await MoveSelectedItem(col, row);
    }

    public async Task MoveItemByDelta(int deltaCol, int deltaRow) =>
        await MoveSelectedItemByDelta(deltaCol, deltaRow);

    public async Task ResizeItemWidth(GridItem item, int delta)
    {
        int newColSpan = item.ColumnSpan + delta;

        if (newColSpan < 1)
        {
            newColSpan = 1;
        }

        if (newColSpan > Layout.Columns)
        {
            newColSpan = Layout.Columns;
        }

        if (item.Column + newColSpan - 1 > Layout.Columns)
        {
            return;
        }

        int originalColSpan = item.ColumnSpan;
        item.ColumnSpan = newColSpan;

        if (_collisionService.HasCollision(item, item.Column, item.Row))
        {
            item.ColumnSpan = originalColSpan;
            return;
        }

        await LayoutChanged.InvokeAsync(Layout);
        await InvokeAsync(StateHasChanged);
    }

    public async Task ResizeItemHeight(GridItem item, int delta)
    {
        int newRowSpan = item.RowSpan + delta;

        if (newRowSpan < 1)
        {
            newRowSpan = 1;
        }

        if (newRowSpan > Layout.Rows)
        {
            newRowSpan = Layout.Rows;
        }

        if (item.Row + newRowSpan - 1 > Layout.Rows)
        {
            return;
        }

        int originalRowSpan = item.RowSpan;
        item.RowSpan = newRowSpan;

        if (_collisionService.HasCollision(item, item.Column, item.Row))
        {
            item.RowSpan = originalRowSpan;
            return;
        }

        await LayoutChanged.InvokeAsync(Layout);
        await InvokeAsync(StateHasChanged);
    }

    public async Task DeselectItem() =>
        await SelectedItemChanged.InvokeAsync(null);


    public void Dispose()
    {
        _collisionService = null;
        _placementService = null;
        _styleService = null;
        _dragService = null;
    }
}