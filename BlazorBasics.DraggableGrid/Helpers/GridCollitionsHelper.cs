namespace BlazorBasics.DraggableGrid.Helpers;

internal static class GridCollitionsHelper
{
    public static List<GridObject> GetCollisions(
                GridSnapshot snapshot,
                GridObject obj,
                GridPosition newPosition)
    {
        // Validación temprana: si ni siquiera el source cabe en target → imposible
        if (MovementHelper.IsOutOfBounds(snapshot, obj, newPosition.Row, newPosition.Column))
            return new List<GridObject>();

        HashSet<string> visited = new HashSet<string>();
        List<GridObject> result = new List<GridObject>();
        Direction direction = MovementHelper.GetDirection(obj.Position, newPosition);

        CollectCollisions(snapshot, obj, newPosition, visited, result, direction);

        return result;
    }

    private static void CollectCollisions(
        GridSnapshot snapshot,
        GridObject obj,                    // el objeto que estamos intentando colocar (source o empujado)
        GridPosition position,             // posición donde intentamos colocarlo
        HashSet<string> visited,
        List<GridObject> result,
        Direction direction)
    {
        // Si la posición está fuera de bounds → no iteramos celdas, pero el objeto que causó esta llamada
        // ya fue agregado por el caller (porque colisionó con él). Solo cortamos recursión.
        if (MovementHelper.IsOutOfBounds(snapshot, obj, position.Row, position.Column))
            return;

        int startRow = position.Row;
        int startCol = position.Column;
        int endRow = startRow + obj.Size.Height - 1;
        int endCol = startCol + obj.Size.Width - 1;

        for (int r = startRow; r <= endRow; r++)
        {
            for (int c = startCol; c <= endCol; c++)
            {
                GridObject current = snapshot.Cells[r, c];
                if (current != null &&
                    !current.Equals(obj) &&
                    !visited.Contains(current.Id))
                {
                    visited.Add(current.Id);
                    result.Add(current); // ¡SIEMPRE agregamos el objeto colisionado!

                    // Ahora intentamos ver qué colisionaría este 'current' si lo empujamos
                    GridPosition nextPos = MovementHelper.CalculateNextPosition(current.Position, direction);

                    // Aquí está la clave: solo recursamos si el próximo paso es válido
                    // Si no lo es → no llamamos recursión → no agregamos objetos más allá
                    // Pero 'current' ya está en result → será procesado en el bucle de Move
                    if (!MovementHelper.IsOutOfBounds(snapshot, current, nextPos.Row, nextPos.Column))
                    {
                        CollectCollisions(snapshot, current, nextPos, visited, result, direction);
                    }
                    // Si está fuera → no recursamos, pero 'current' sigue en la lista → será rebotado después
                }
            }
        }
    }

    public static bool CanFit(
      GridSnapshot snapshot,
      GridObject obj,
      int row,
      int col)
    {
        bool result = true;

        int endRow = row + obj.Size.Height - 1;
        int endCol = col + obj.Size.Width - 1;

        if (row < 0 || col < 0 ||
            endRow >= snapshot.Rows ||
            endCol >= snapshot.Columns)
        {
            result = false;
        }

        if (result)
        {
            for (int r = row; r <= endRow; r++)
            {
                for (int c = col; c <= endCol; c++)
                {
                    GridObject current = snapshot.Cells[r, c];
                    if (current != null && !current.Equals(obj))
                    {
                        result = false;
                    }
                }
            }
        }

        return result;
    }
}