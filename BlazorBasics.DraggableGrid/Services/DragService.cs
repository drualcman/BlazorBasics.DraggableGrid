internal class DragService
{
    private readonly GridLayout _layout;

    public DragService(GridLayout layout)
    {
        _layout = layout;
    }

    public (int Col, int Row)? CalculateDragTarget(MouseEventArgs e,
        DragState dragState, GridItem draggingItem)
    {
        if (!dragState.DragStartMouse.HasValue || !dragState.DragStartCell.HasValue)
            return null;

        double containerWidth = _layout.Columns * 1.0; // proporción de columnas
        double containerHeight = _layout.Rows * 1.0;   // proporción de filas

        (int startX, int startY) = dragState.DragStartMouse.Value;
        (int startCol, int startRow) = dragState.DragStartCell.Value;

        int deltaX = (int)e.ClientX - startX;
        int deltaY = (int)e.ClientY - startY;

        if (Math.Abs(deltaX) < 8 && Math.Abs(deltaY) < 8)
            return null;

        // proporción del delta respecto al contenedor
        double colFraction = deltaX / containerWidth;
        double rowFraction = deltaY / containerHeight;

        int deltaCol = (int)Math.Round(colFraction * _layout.Columns);
        int deltaRow = (int)Math.Round(rowFraction * _layout.Rows);

        int hoverCol = Math.Clamp(startCol + deltaCol, 1, _layout.Columns);
        int hoverRow = Math.Clamp(startRow + deltaRow, 1, _layout.Rows);

        int maxCol = _layout.Columns - draggingItem.ColumnSpan + 1;
        int maxRow = _layout.Rows - draggingItem.RowSpan + 1;

        int finalCol = Math.Clamp(hoverCol, 1, maxCol);
        int finalRow = Math.Clamp(hoverRow, 1, maxRow);

        return (finalCol, finalRow);
    }
}
