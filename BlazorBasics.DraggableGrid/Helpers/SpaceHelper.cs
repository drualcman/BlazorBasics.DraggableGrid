namespace BlazorBasics.DraggableGrid.Helpers;

internal static class SpaceHelper
{
    public static bool ReserveFutureArea(
        GridSnapshot snapshot,
        GridObject obj,
        GridPosition futurePosition)
    {
        int startRow = futurePosition.Row;
        int startCol = futurePosition.Column;

        if (MovementHelper.IsOutOfBounds(snapshot, obj, startRow, startCol))
            return false;

        int endRow = startRow + obj.Size.Height - 1;
        int endCol = startCol + obj.Size.Width - 1;

        for (int r = startRow; r <= endRow; r++)
        {
            for (int c = startCol; c <= endCol; c++)
            {
                snapshot.Cells[r, c] = obj;
            }
        }
        return true;
    }
    public static void ClearReservation(
      GridSnapshot snapshot,
      GridObject obj)
    {
        for (int r = 0; r < snapshot.Rows; r++)
        {
            for (int c = 0; c < snapshot.Columns; c++)
            {
                GridObject current = snapshot.Cells[r, c];
                if (current != null && current.Equals(obj))
                {
                    snapshot.Cells[r, c] = null;
                }
            }
        }
    }
}