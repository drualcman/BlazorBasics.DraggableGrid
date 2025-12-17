namespace BlazorBasics.DraggableGrid.Services;

internal class GridStyleService
{
    private readonly GridLayout _layout;
    private readonly GridTheme _theme;

    public GridStyleService(GridLayout layout, GridTheme theme)
    {
        _layout = layout;
        _theme = theme;
    }

    public string GetGridStyle()
    {
        return "display: grid; " +
               $"grid-template-columns: repeat({_layout.Columns}, {_layout.ColumnSize}); " +
               $"grid-template-rows: repeat({_layout.Rows}, {_layout.RowSize}); " +
               $"gap: {_layout.Gap}; " +
               $"overflow: {_layout.Overflow};" +
               "width: 100%; " +
               "height: auto;";
    }

    public string GetItemStyle(GridObject item, bool isSelected, bool isDragging)
    {
        string borderColor = isSelected ? _theme.SelectedColor :
                             isDragging ? _theme.DraggingColor : "var(--item-border)";
        string borderStyle = isSelected ? "3px solid" :
                             isDragging ? "3px dashed" : "2px solid";
        string boxShadow = isSelected ? $"0 0 0 3px {_theme.SelectedGlowColor}" :
                             isDragging ? $"0 10px 30px {_theme.DraggingGlowColor}" : "none";

        return $"grid-column-start: {item.Position.Column + 1}; " +
               $"grid-column-end:  span {item.Size.Width}; " +
               $"grid-row-start: {item.Position.Row + 1}; " +
               $"grid-row-end: span {item.Size.Height}; " +
               $"border: {borderStyle} {borderColor}; " +
               $"box-shadow: {boxShadow}; " +
               $"z-index: {(isSelected || isDragging ? "100" : "10")};" +
               $"{(isDragging ? "opacity: 0.8; cursor: grabbing;" : "cursor: grab;")}";
    }

    public string GetCellStyle(int row, int column, bool isDragging)
    {
        return $"grid-column-start: {column + 1}; " +
               $"grid-column-end:  {column + 1}; " +
               $"grid-row-start: {row + 1}; " +
               $"grid-row-end: {row + 1}; " +
               (isDragging ? $"pointer-events: none;" : "");
    }
}