namespace BlazorBasics.DraggableGrid.Models;

public sealed class GridItem : GridObject
{
    public GridItem(GridPosition position, GridSize size, string id = "")
       : base(id, position, size)
    {
    }

    public object Data { get; set; }

    // Métodos helper para tipado seguro
    public T GetData<T>() => (T)Data!;
    public bool IsDataOfType<T>() => Data is T;
}
