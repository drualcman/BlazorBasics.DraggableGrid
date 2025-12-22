namespace BlazorBasics.DraggableGrid.Helpers;

internal static class ReplaceHelper
{
    public static GridSnapshot TryReplaceObject(
        GridSnapshot baseSnapshot,
        GridObject source,
        GridObject firstColliding,
        GridPosition target,
        Direction direction)
    {
        if (source.CanReplace(firstColliding, target))
        {
            GridPosition sourceOriginalPos = source.Position;
            GridSnapshot replaceSnapshot = baseSnapshot.Clone();
            PlaceObjectHelper.TryPlaceObject(
                replaceSnapshot, source, firstColliding.Position, direction, allowReplace: true);
            PlaceObjectHelper.TryPlaceObject(
                replaceSnapshot, firstColliding, sourceOriginalPos, MovementHelper.GetOppositeDirection(direction), allowReplace: false);
            return replaceSnapshot;
        }
        return null;
    }
}
