namespace BlazorBasics.DraggableGrid.Helpers;

internal static class PositionHelper
{
    public static bool TryFindFreePosition2D(
         GridSnapshot snapshot,
         GridObject obj,
         GridPosition target,
         Direction direction,
         out GridPosition freePosition)
    {
        Queue<GridPosition> queue = new Queue<GridPosition>();
        HashSet<string> visited = new HashSet<string>();

        queue.Enqueue(obj.Position);
        visited.Add($"{obj.Position.Row}-{obj.Position.Column}");

        int maxSteps = snapshot.Rows + snapshot.Columns;

        while (queue.Count > 0 && maxSteps-- > 0)
        {
            GridPosition current = queue.Dequeue();

            // Check if object can fit here
            if (GridCollitionsHelper.CanFit(snapshot, obj, current.Row, current.Column))
            {
                freePosition = current;
                return true;
            }

            // Explore neighbors in order of preference: horizontal first, then vertical
            List<GridPosition> neighbors = direction switch
            {
                Direction.Down or Direction.DownLeft or Direction.DownRight => new List<GridPosition>
                {
                    new GridPosition(current.Row + 1, current.Column),     // Down primero
                    new GridPosition(current.Row, current.Column - 1),     // Left
                    new GridPosition(current.Row, current.Column + 1),     // Right
                    new GridPosition(current.Row - 1, current.Column),     // Up (último)
                },
                Direction.Up or Direction.UpLeft or Direction.UpRight => new List<GridPosition>
                {
                    new GridPosition(current.Row - 1, current.Column),     // Up primero
                    new GridPosition(current.Row, current.Column - 1),
                    new GridPosition(current.Row, current.Column + 1),
                    new GridPosition(current.Row + 1, current.Column),
                },
                Direction.Left => new List<GridPosition>
                {
                    new GridPosition(current.Row, current.Column - 1),     // Left primero
                    new GridPosition(current.Row - 1, current.Column),
                    new GridPosition(current.Row + 1, current.Column),
                    new GridPosition(current.Row, current.Column + 1),
                },
                Direction.Right => new List<GridPosition>
                {
                    new GridPosition(current.Row, current.Column + 1),     // Right primero
                    new GridPosition(current.Row - 1, current.Column),
                    new GridPosition(current.Row + 1, current.Column),
                    new GridPosition(current.Row, current.Column - 1),
                },
                _ => new List<GridPosition>
                {
                    new GridPosition(current.Row, current.Column - 1),
                    new GridPosition(current.Row, current.Column + 1),
                    new GridPosition(current.Row - 1, current.Column),
                    new GridPosition(current.Row + 1, current.Column),
                }
            };

            for (int i = 0; i < neighbors.Count; i++)
            {
                GridPosition neighbor = neighbors[i];
                string key = $"{neighbor.Row}-{neighbor.Column}";
                if (!visited.Contains(key) && !MovementHelper.IsOutOfBounds(snapshot, obj, neighbor.Row, neighbor.Column))
                {
                    queue.Enqueue(neighbor);
                    visited.Add(key);
                }
            }
        }

        freePosition = obj.Position;
        return false;
    }
}