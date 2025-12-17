namespace BlazorBasics.DraggableGrid.Models;

public class GridInternalLayout(int rows = 10, int columns = 10)
{
    public int Columns { get; set; } = columns;
    public int Rows { get; set; } = rows;
}