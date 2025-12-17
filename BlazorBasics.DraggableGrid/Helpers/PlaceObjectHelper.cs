namespace BlazorBasics.DraggableGrid.Helpers;

internal static class PlaceObjectHelper
{
    public static bool TryPlaceObject(
        GridSnapshot snapshot,
        GridObject obj,
        GridPosition newPosition,
        Direction direction,
        bool allowReplace = true)
    {
        List<GridObject> collidingObjects = GridCollitionsHelper.GetCollisions(snapshot, obj, newPosition);

        if (collidingObjects.Count == 1 && allowReplace)
        {
            GridObject other = collidingObjects[0];

            if (obj.CanReplace(other, newPosition))
            {
                ObjectHelper.ClearObject(snapshot, other);
                ObjectHelper.ClearObject(snapshot, obj);

                GridPosition oldPosition = obj.Position;

                other.MoveTo(oldPosition);
                obj.MoveTo(newPosition);

                ObjectHelper.PlaceObject(snapshot, other);
                ObjectHelper.PlaceObject(snapshot, obj);

                return true;
            }
        }

        bool result = true;

        // Reserve future area of the moving object
        bool reserved = SpaceHelper.ReserveFutureArea(snapshot, obj, newPosition);
        if (!reserved)
        {
            SpaceHelper.ClearReservation(snapshot, obj);
            return false;
        }

        for (int i = 0; i < collidingObjects.Count; i++)
        {
            GridObject other = collidingObjects[i];

            GridPosition freePosition;
            bool canMove = PositionHelper.TryFindFreePosition2D(snapshot, other, newPosition, direction, out freePosition);

            bool pushed = false;

            if (canMove)
            {
                // Recursive move, but do not allow replacement after first move
                pushed = TryPlaceObject(snapshot, other, freePosition, direction, allowReplace: false);
            }

            if (!pushed)
            {
                result = false;
            }
        }

        SpaceHelper.ClearReservation(snapshot, obj);

        if (result)
        {
            ObjectHelper.ClearObject(snapshot, obj);
            obj.MoveTo(newPosition);
            result = ObjectHelper.PlaceObject(snapshot, obj);
        }

        return result;
    }

    public static void FillOccupedCells(GridObject obj, GridObject[,] grid)
    {
        // Rellenar las celdas ocupadas por el objeto
        var empties = EmptyGridObject.From(obj);
        foreach (var empty in empties)
        {
            grid[empty.Position.Row, empty.Position.Column] = empty;
        }
    }
}