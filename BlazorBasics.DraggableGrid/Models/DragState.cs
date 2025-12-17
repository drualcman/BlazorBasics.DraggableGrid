namespace BlazorBasics.DraggableGrid.Models;

internal class DragState
{
    public GridObject? DraggingItem { get; set; }
    public bool IsDragging { get; set; }
    public string? DragCursorClass { get; set; }
    public GridPosition? DragStartMouse { get; set; }
    public GridPosition? DragCurrentMouse { get; set; }
    public GridPosition? DragStartCell { get; set; }
    public GridPosition? HoverTarget { get; set; }
    public bool DragMoved { get; set; }

    public void Reset()
    {
        DraggingItem = null;
        IsDragging = false;
        DragMoved = false;
        DragCursorClass = null;
        DragStartMouse = new();
        DragStartCell = null;
        HoverTarget = null;
        DragCurrentMouse = null;
    }
}
