namespace BlazorBasics.DraggableGrid.Services;

internal class GridSystem
{
    public GridInternalLayout Layout { get; private set; }
    private Dictionary<string, GridItem> Objects = new();
    public readonly GridObject[,] Grid;
    public readonly GridMovement MovementService;

    public GridSystem(GridInternalLayout layout)
    {
        Layout = layout;
        Grid = new GridObject[Layout.Rows, Layout.Columns];
        MovementService = new GridMovement(this);
        InitializeEmptyGrid();
    }

    public bool TryGetObject(string id, out GridItem obj) =>
        Objects.TryGetValue(id, out obj!);

    public GridItem GetObject(string id)
    {
        if (!string.IsNullOrWhiteSpace(id) && Objects.ContainsKey(id))
            return Objects[id];
        else
            return null;
    }

    public bool HasObject(string id) =>
        !string.IsNullOrWhiteSpace(id) && Objects.ContainsKey(id);

    public GridObject GetByPosition(int row, int col) =>
        Grid[row, col];

    public List<GridItem> GetObjectsAsList() =>
        Objects.Values.ToList();

    public void InitializeEmptyGrid()
    {
        for (int row = 0; row < Layout.Rows; row++)
        {
            for (int col = 0; col < Layout.Columns; col++)
            {
                Grid[row, col] = null;
            }
        }
    }

    public void Upsert(GridItem obj)
    {
        if (!Objects.TryGetValue(obj.Id, out GridItem item))
        {
            Objects.Add(obj.Id, obj);
        }
        Grid[obj.Position.Row, obj.Position.Column] = obj;
        PlaceObjectHelper.FillOccupedCells(obj, Grid);
    }

    public void DeleteObject(GridObject obj)
    {
        int oldCol = obj.Position.Column;
        int oldRow = obj.Position.Row;
        int maxCol = oldCol + obj.Size.Width - 1;
        int maxRow = oldRow + obj.Size.Height - 1;

        for (int r = oldRow; r <= maxRow; r++)
        {
            for (int c = oldCol; c <= maxCol; c++)
            {
                var target = Grid[r, c];
                if (target?.Equals(obj) ?? false)
                    Grid[r, c] = null;
            }
        }
    }

    public bool Move(
        string objectId,
        GridPosition newPosition)
    {
        if (TryGetObject(objectId, out var obj))
        {
            Console.WriteLine($"Move {obj} to {newPosition}");
            GridSnapshot? previewSnapshot = MovementService.TryMoveObject(obj, newPosition);

            if (previewSnapshot != null)
            {
                Console.WriteLine($"Moved {obj}");
                MovementService.ApplySnapshot(previewSnapshot);
            }
        }
        return false;
    }

    public GridSnapshot? PreviewMove(
        string objectId,
        GridPosition newPosition)
    {
        if (TryGetObject(objectId, out var obj))
        {
            return MovementService.TryMoveObject(obj, newPosition);
        }
        return null;
    }
}