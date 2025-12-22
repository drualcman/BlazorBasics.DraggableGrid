namespace BlazorBasics.DraggableGrid.Handlers;

internal class GridMovement(GridSystem gridSystem)
{
    public GridSnapshot? TryMoveObject(GridObject source, GridPosition target)
    {
        GridSnapshot baseSnapshot = CreateSnapshot();
        if (MovementHelper.IsOutOfBounds(baseSnapshot, source, target.Row, target.Column))
            return null;

        Direction direction = MovementHelper.GetDirection(source.Position, target);

        List<GridObject> collidingObjects = GridCollitionsHelper.GetCollisions(baseSnapshot, source, target);

        if (collidingObjects.Count == 0)
        {
            var attempt = baseSnapshot.Clone();
            if (PlaceObjectHelper.TryPlaceObject(attempt, source, target, direction))
                return attempt;

            return null;
        }

        if (collidingObjects.Count > 0)
        {
            GridObject firstColliding = collidingObjects[0];
            var replaceSnapshot = ReplaceHelper.TryReplaceObject(baseSnapshot, source, firstColliding, target, direction);
            if (replaceSnapshot is not null)
                return replaceSnapshot;
        }

        GridSnapshot workingSnapshot = baseSnapshot.Clone();

        foreach (GridObject other in collidingObjects)
        {
            GridPosition freePosition;
            bool canMove = PositionHelper.TryFindFreePosition2D(workingSnapshot, other, target, direction, out freePosition);

            if (canMove)
            {
                if (!PlaceObjectHelper.TryPlaceObject(workingSnapshot, other, freePosition, direction, allowReplace: false))
                    return null;
            }
            else
            {
                GridPosition reboundTarget = source.Position;
                ObjectHelper.ClearObject(workingSnapshot, source);

                bool reboundToTail = PlaceObjectHelper.TryPlaceObject(
                    workingSnapshot, other, reboundTarget, direction, allowReplace: false);

                if (!reboundToTail)
                {
                    Direction perp1 = MovementHelper.GetPerpendicularDirection(direction, isLeft: true);
                    Direction perp2 = MovementHelper.GetPerpendicularDirection(direction, isLeft: false);
                    GridPosition perpPos1 = MovementHelper.CalculateNextPosition(other.Position, perp1);
                    GridPosition perpPos2 = MovementHelper.CalculateNextPosition(other.Position, perp2);

                    reboundToTail = PlaceObjectHelper.TryPlaceObject(workingSnapshot, other, perpPos1, perp1, allowReplace: false) ||
                                    PlaceObjectHelper.TryPlaceObject(workingSnapshot, other, perpPos2, perp2, allowReplace: false);
                }

                if (!reboundToTail)
                    return null;
            }
        }

        if (PlaceObjectHelper.TryPlaceObject(workingSnapshot, source, target, direction, allowReplace: false))
            return workingSnapshot;

        return null;
    }

    public void ApplySnapshot(GridSnapshot snapshot)
    {
        gridSystem.InitializeEmptyGrid();
        for (int r = 0; r < snapshot.Rows; r++)
        {
            for (int c = 0; c < snapshot.Columns; c++)
            {
                GridObject obj = snapshot.Cells[r, c];
                if (obj != null && !obj.IsEmptyObject())
                {
                    var original = gridSystem.GetObject(obj.Id);
                    Console.WriteLine($"Moving object {original} to {obj}");
                    gridSystem.Upsert(original);
                }
            }
        }
    }

    private GridSnapshot CreateSnapshot()
    {
        List<GridItem> objects = gridSystem.GetObjectsAsList();
        return GridSnapshot.CreateSnapshot(gridSystem.Layout, objects);
    }
}