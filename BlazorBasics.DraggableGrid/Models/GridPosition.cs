namespace BlazorBasics.DraggableGrid.Models;

public struct GridPosition
{
    public int Column { get; set; }
    public int Row { get; set; }

    public GridPosition(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public override string ToString() => $"({Row}, {Column})";

}
