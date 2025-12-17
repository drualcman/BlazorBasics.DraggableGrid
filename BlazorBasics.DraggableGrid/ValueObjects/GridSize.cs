namespace BlazorBasics.DraggableGrid.ValueObjects;

public struct GridSize
{
    public int Width { get; set; }
    public int Height { get; set; }

    public GridSize(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public override string ToString() => $"{Width}x{Height}";
}
