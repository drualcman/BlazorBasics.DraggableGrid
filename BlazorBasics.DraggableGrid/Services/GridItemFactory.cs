namespace BlazorBasics.DraggableGrid.Services;

public static class GridItemFactory
{
    public static GridItem CreateNewItem(int index)
    {
        var random = new Random();

        return new GridItem(new GridPosition(index, 1), new GridSize(2, 2))
        {
            Data = default!
        };
    }
}
