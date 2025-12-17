internal sealed class EmptyGridObject : GridObject
{
    private EmptyGridObject(string id, GridPosition position)
        : base($"_{id}", position, new GridSize(1, 1))
    {
    }

    /// <summary>
    /// Genera objetos EmptyGridObject (1x1) que representan las casillas adyacentes 
    /// inmediatamente a la derecha (una columna completa) y debajo (una fila completa) 
    /// del objeto relativo. La esquina inferior-derecha no se duplica.
    /// Si el objeto es 1x1, devuelve un array vacío.
    /// </summary>
    /// <param name="relative">Objeto respecto al cual generar los vacíos adyacentes.</param>
    /// <returns>Array de EmptyGridObject en las posiciones adyacentes derecha y abajo.</returns>
    public static GridObject[] From(GridObject relative)
    {
        if (relative == null)
            throw new ArgumentNullException(nameof(relative));

        int width = relative.Size.Width;
        int height = relative.Size.Height;

        // Si es 1x1, no generamos nada
        if (width == 1 && height == 1)
            return Array.Empty<GridObject>();

        var list = new List<GridObject>();

        int baseCol = relative.Position.Column;
        int baseRow = relative.Position.Row;

        // Corrección: iterar sobre todo el área del objeto
        for (int r = baseRow; r < baseRow + height; r++)
        {
            for (int c = baseCol; c < baseCol + width; c++)
            {
                // Excluimos solo la celda principal (esquina superior-izquierda)
                if (!(c == baseCol && r == baseRow))
                {
                    var pos = new GridPosition(r, c);
                    list.Add(new EmptyGridObject(relative.Id, pos));
                }
            }
        }

        return list.ToArray();
    }
}