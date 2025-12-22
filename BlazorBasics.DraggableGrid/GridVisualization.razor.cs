using System.Text.Json;

namespace BlazorBasics.DraggableGrid;

public partial class GridVisualization<TData> : IDisposable
{
    [Parameter] public GridLayout Layout { get; set; } = new();
    [Parameter] public RenderFragment<TData>? ChildContent { get; set; }
    [Parameter] public EventCallback<GridItem?> SelectedItemChanged { get; set; }
    [Parameter] public EventCallback<GridLayout> LayoutChanged { get; set; }
    [Parameter] public EventCallback<GridItem> OnItemRemoved { get; set; }
    [Parameter] public bool AllowDragAndDrop { get; set; } = true;
    [Parameter] public bool AllowKeyboardControls { get; set; } = false;
    [Parameter] public GridTheme Theme { get; set; } = GridTheme.Default;

    private GridObject? SelectedItem;
    private DragState _dragState = new();
    private GridSystem _gridSystem;
    private GridStyleService _styleService;
    private bool _initialized = false;

    protected override void OnParametersSet()
    {
        if (!_initialized)
        {
            _initialized = true;
        }
        string data = JsonSerializer.Serialize(Layout);
        InitializeServices();
    }

    private void InitializeServices()
    {
        _styleService = new GridStyleService(Layout, Theme);
        _gridSystem = new GridSystem(new GridInternalLayout(Layout.Rows, Layout.Columns));
        foreach (var item in Layout.Items)
        {
            _gridSystem.Upsert(item);
        }
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

    private string GetItemStyle(GridObject item)
    {
        bool isSelected = SelectedItem?.Id == item.Id;
        bool isDragging = _dragState.DraggingItem?.Id == item.Id;
        return _styleService.GetItemStyle(item, isSelected, isDragging);
    }

    private string GetCellStyle(int row, int col, bool isDragging = false) =>
        _styleService.GetCellStyle(row, col, isDragging);

    private Task StartMouseDown(GridObject item)
    {
        _dragState.DraggingItem = item;
        if (!AllowDragAndDrop)
            return Task.CompletedTask;
        _dragState.IsDragging = false;
        _dragState.DragMoved = false;

        _dragState.DragStartMouse = item.Position;
        _dragState.DragCurrentMouse = item.Position;
        _dragState.DragStartCell = item.Position;
        return Task.CompletedTask;
    }

    private Task HandleMouseMove(int row, int col)
    {
        if (_dragState.DraggingItem is not null)
        {
            GridPosition current = new GridPosition(row, col);
            _dragState.DragCurrentMouse = current;

            bool hasMovedFromOrigin =
                current.Row != _dragState.DraggingItem.Position.Row ||
                current.Column != _dragState.DraggingItem.Position.Column;

            if (hasMovedFromOrigin)
            {
                _dragState.DragMoved = true;
                _dragState.IsDragging = true;
            }
        }
        return Task.CompletedTask;
    }

    private async Task HandleMouseUp(MouseEventArgs e)
    {
        if (_dragState.IsDragging && _dragState.DraggingItem is not null)
        {
            if (_gridSystem.Move(_dragState.DraggingItem.Id, _dragState.DragCurrentMouse.Value))
            {
                await SelectedItemChanged.InvokeAsync(_gridSystem.GetObject(_dragState.DraggingItem.Id));
                await LayoutChanged.InvokeAsync(Layout);
            }
            SelectedItem = null;
        }
        else
        {
            if (_dragState.DragMoved == false && _dragState.DraggingItem is not null)
            {
                if (SelectedItem is not null && SelectedItem.Id == _dragState.DraggingItem.Id)
                    SelectedItem = null;
                else
                    SelectedItem = _dragState.DraggingItem;

                await SelectedItemChanged.InvokeAsync(_gridSystem.GetObject(SelectedItem?.Id));
            }
        }
        await CleanUpDrag();
    }

    private async Task CleanUpDrag()
    {
        _dragState.Reset();
        await InvokeAsync(StateHasChanged);
    }

    private async Task CellClicked(int row, int col)
    {
        if (_dragState.IsDragging)
            return;

        if (SelectedItem is not null)
        {
            await MoveSelectedItem(row, col);
        }
        await InvokeAsync(StateHasChanged);
    }

    private async Task MoveSelectedItem(int targetRow, int targetCol)
    {
        if (_gridSystem.Move(SelectedItem?.Id, new GridPosition(targetRow, targetCol)))
        {
            await SelectedItemChanged.InvokeAsync(_gridSystem.GetObject(SelectedItem?.Id));
            await LayoutChanged.InvokeAsync(Layout);
        }
    }

    public async Task MoveItemByDelta(int deltaRow, int deltaCol)
    {
        if (SelectedItem is null)
            return;

        int newCol = SelectedItem.Position.Column + deltaCol;
        int newRow = SelectedItem.Position.Row + deltaRow;

        await MoveSelectedItem(newRow, newCol);
        await InvokeAsync(StateHasChanged);
    }

    private async Task HandleKeyDown(KeyboardEventArgs e)
    {
        if (!AllowKeyboardControls)
            return;
        switch (e.Key)
        {
            case "ArrowUp":
                await MoveItemByDelta(-1, 0);
                break;
            case "ArrowDown":
                await MoveItemByDelta(1, 0);
                break;
            case "ArrowLeft":
                await MoveItemByDelta(0, -1);
                break;
            case "ArrowRight":
                await MoveItemByDelta(0, 1);
                break;
            case "Delete":
            case "Backspace":
                if (SelectedItem is not null)
                {
                    await OnItemRemoved.InvokeAsync(_gridSystem.GetObject(SelectedItem?.Id));
                }
                break;
            case "Escape":
                SelectedItem = null;
                await CleanUpDrag();
                await SelectedItemChanged.InvokeAsync(null);
                break;
            case " ":
                if (SelectedItem is not null)
                {
                    SelectedItem = null;
                    await CleanUpDrag();
                    await SelectedItemChanged.InvokeAsync(null);
                }
                else if (Layout.Items.Any())
                {
                    var selection = Layout.Items.First();
                    SelectedItem = selection;
                    await SelectedItemChanged.InvokeAsync(selection);
                }
                break;
        }
    }

    public async Task ResizeItemWidth(GridItem item, int delta)
    {
        int newColSpan = item.Size.Width + delta;

        if (newColSpan < 1)
        {
            newColSpan = 1;
        }

        if (newColSpan > Layout.Columns)
        {
            newColSpan = Layout.Columns;
        }

        if (item.Position.Column + newColSpan - 1 > Layout.Columns)
        {
            return;
        }


        int originalColSpan = item.Size.Width;
        item.Resize(new(newColSpan, item.Size.Height));
        var snapshot = _gridSystem.PreviewMove(item.Id, item.Position);
        if (snapshot is not null)
        {
            if (_gridSystem.Move(item.Id, item.Position))
            {
                await SelectedItemChanged.InvokeAsync(_gridSystem.GetObject(item.Id));
                await LayoutChanged.InvokeAsync(Layout);
            }
        }
        else
            item.Resize(new(originalColSpan, item.Size.Height));
    }

    public async Task ResizeItemHeight(GridItem item, int delta)
    {
        int newRowSpan = item.Size.Height + delta;

        if (newRowSpan < 1)
        {
            newRowSpan = 1;
        }

        if (newRowSpan > Layout.Rows)
        {
            newRowSpan = Layout.Rows;
        }

        if (item.Position.Row + newRowSpan - 1 > Layout.Rows)
        {
            return;
        }

        int originalRowSpan = item.Size.Height;
        item.Resize(new(item.Size.Width, newRowSpan));
        var snapshot = _gridSystem.PreviewMove(item.Id, item.Position);
        if (snapshot is not null)
        {
            if (_gridSystem.Move(item.Id, item.Position))
            {
                await SelectedItemChanged.InvokeAsync(_gridSystem.GetObject(item.Id));
                await LayoutChanged.InvokeAsync(Layout);
            }
        }
        else
            item.Resize(new(originalRowSpan, item.Size.Height));
    }

    public async Task DeselectItem()
    {
        SelectedItem = null;
        await SelectedItemChanged.InvokeAsync(null);
    }

    public void Dispose()
    {
        _styleService = null;
        _gridSystem = null;
    }
}