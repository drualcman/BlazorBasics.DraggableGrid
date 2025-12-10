namespace BlazorBasics.DraggableGrid.Models;

public class GridLayout
{
    public int Columns { get; set; } = 8;
    public int Rows { get; set; } = 10;
    public string ColumnSize { get; set; } = "minmax(50px, 1fr)"; // flexible
    public string RowSize { get; set; } = "auto"; // adaptable
    public string Gap { get; set; } = "0";
    public List<GridItem> Items { get; set; } = new();
}
