namespace BlazorBasics.DraggableGrid.Helpers;

internal static class ObjectHelper
{
    public static bool PlaceObject(GridSnapshot grid, GridObject obj)
    {
        int startRow = obj.Position.Row;
        int startCol = obj.Position.Column;

        if (MovementHelper.IsOutOfBounds(grid, obj, startRow, startCol))
            return false;

        int endRow = startRow + obj.Size.Height - 1;
        int endCol = startCol + obj.Size.Width - 1;

        for (int r = startRow; r <= endRow; r++)
        {
            for (int c = startCol; c <= endCol; c++)
            {
                grid.Cells[r, c] = obj;
            }
        }
        return true;
    }

    public static void ClearObject(GridSnapshot grid, GridObject obj)
    {
        for (int r = 0; r < grid.Rows; r++)
        {
            for (int c = 0; c < grid.Columns; c++)
            {
                GridObject current = grid.Cells[r, c];
                if (current != null && current.Equals(obj))
                {
                    grid.Cells[r, c] = null;
                }
            }
        }
    }
}
