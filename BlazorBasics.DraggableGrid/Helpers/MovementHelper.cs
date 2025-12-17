namespace BlazorBasics.DraggableGrid.Helpers;

internal static class MovementHelper
{
    public static GridPosition CalculateNextPosition(GridPosition position, Direction direction)
    {
        int row = position.Row;
        int col = position.Column;

        int deltaCol = 0, deltaRow = 0;
        switch (direction)
        {
            case Direction.Up:
                deltaRow = -1;
                break;
            case Direction.Down:
                deltaRow = 1;
                break;
            case Direction.Left:
                deltaCol = -1;
                break;
            case Direction.Right:
                deltaCol = 1;
                break;
            case Direction.UpLeft:
                deltaRow = -1;
                deltaCol = -1;
                break;
            case Direction.UpRight:
                deltaRow = -1;
                deltaCol = 1;
                break;
            case Direction.DownLeft:
                deltaRow = 1;
                deltaCol = -1;
                break;
            case Direction.DownRight:
                deltaRow = 1;
                deltaCol = 1;
                break;
        }

        return new GridPosition(row + deltaRow, col + deltaCol);
    }

    public static bool IsOutOfBounds(
       GridSnapshot snapshot,
       GridObject obj,
       int row,
       int col)
    {
        int endRow = row + obj.Size.Height - 1;
        int endCol = col + obj.Size.Width - 1;

        bool result =
            row < 0 ||
            col < 0 ||
            endRow >= snapshot.Rows ||
            endCol >= snapshot.Columns;

        return result;
    }

    public static Direction GetOppositeDirection(Direction direction)
    {
        Direction result = direction;

        if (direction == Direction.Up)
            result = Direction.Down;
        if (direction == Direction.Down)
            result = Direction.Up;
        if (direction == Direction.Left)
            result = Direction.Right;
        if (direction == Direction.Right)
            result = Direction.Left;

        return result;
    }

    public static Direction GetDirection(GridPosition from, GridPosition to)
    {
        // Caso especial: misma posición
        if (from.Column == to.Column && from.Row == to.Row)
            return Direction.None;
        int deltaColumn = to.Column - from.Column;  // negativo = izquierda, positivo = derecha
        int deltaRow = to.Row - from.Row;           // negativo = arriba, positivo = abajo
        bool mueveIzquierda = deltaColumn < 0;
        bool mueveDerecha = deltaColumn > 0;
        bool mueveArriba = deltaRow < 0;
        bool mueveAbajo = deltaRow > 0;
        if (mueveArriba)
        {
            if (mueveIzquierda)
                return Direction.UpLeft;
            if (mueveDerecha)
                return Direction.UpRight;
            return Direction.Up;  // solo arriba
        }
        if (mueveAbajo)
        {
            if (mueveIzquierda)
                return Direction.DownLeft;
            if (mueveDerecha)
                return Direction.DownRight;
            return Direction.Down;  // solo abajo
        }
        if (mueveIzquierda)
            return Direction.Left;
        if (mueveDerecha)
            return Direction.Right;
        return Direction.None;
    }

    public static Direction GetPerpendicularDirection(Direction direction, bool isLeft = true)
    {
        return direction switch
        {
            Direction.Up => isLeft ? Direction.Left : Direction.Right,
            Direction.Down => isLeft ? Direction.Right : Direction.Left,
            Direction.Left => isLeft ? Direction.Down : Direction.Up,
            Direction.Right => isLeft ? Direction.Up : Direction.Down,

            // Para diagonales, mantenemos coherencia: izquierda = más hacia arriba/izquierda
            Direction.UpLeft => isLeft ? Direction.DownLeft : Direction.UpRight,
            Direction.UpRight => isLeft ? Direction.UpLeft : Direction.DownRight,
            Direction.DownLeft => isLeft ? Direction.DownRight : Direction.UpLeft,
            Direction.DownRight => isLeft ? Direction.DownLeft : Direction.UpRight,

            _ => Direction.None
        };
    }

}