namespace BlazorBasics.DraggableGrid.Models;

public class GridLayout
{
    public int Columns { get; set; } = 10;
    public int Rows { get; set; } = 10;
    public string ColumnSize { get; set; } = "minmax(150px, 1fr)"; // flexible
    public string RowSize { get; set; } = "minmax(150px, auto)"; // adaptable
    public string Gap { get; set; } = "0";
    public string Overflow { get; set; } = "auto";
    public List<GridItem> Items { get; set; } = new();
}
