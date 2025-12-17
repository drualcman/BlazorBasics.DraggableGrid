namespace BlazorBasics.DraggableGrid.Models;

internal class GridSnapshot
{
    public GridObject[,] Cells { get; }
    public int Rows { get; }
    public int Columns { get; }

    private GridSnapshot(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
        Cells = new GridObject[rows, columns];
    }

    public static GridSnapshot CreateSnapshot(GridInternalLayout layout, List<GridItem> objects)
    {
        int rows = layout.Rows;
        int columns = layout.Columns;

        GridSnapshot snapshot = new GridSnapshot(rows, columns);

        for (int i = 0; i < objects.Count; i++)
        {
            ObjectHelper.PlaceObject(snapshot, objects[i]);
        }

        return snapshot;
    }

    public GridSnapshot Clone()
    {
        GridSnapshot clone = new GridSnapshot(Rows, Columns);

        for (int r = 0; r < Rows; r++)
        {
            for (int c = 0; c < Columns; c++)
            {
                GridObject obj = Cells[r, c];
                if (obj != null && !obj.IsEmptyObject())
                {
                    ObjectHelper.PlaceObject(clone, obj);
                }
            }
        }

        return clone;
    }
}

