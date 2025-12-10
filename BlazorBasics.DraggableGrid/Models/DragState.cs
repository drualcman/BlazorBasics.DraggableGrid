namespace BlazorBasics.DraggableGrid.Models;

internal class DragState
{
    public GridItem? DraggingItem { get; set; }
    public bool IsDragging { get; set; }
    public string? DragCursorClass { get; set; }
    public (int ClientX, int ClientY)? DragStartMouse { get; set; }
    public (int X, int Y)? DragCurrentMouse { get; set; }
    public (int Col, int Row)? DragStartCell { get; set; }
    public (int Col, int Row)? HoverTarget { get; set; }
    public (int Col, int Row)? FinalDropTarget { get; set; }
    public bool DragMoved { get; set; }

    public void Reset()
    {
        DraggingItem = null;
        IsDragging = false;
        DragMoved = false;
        DragCursorClass = null;
        DragStartMouse = (0, 0);
        DragStartCell = null;
        HoverTarget = null;
        FinalDropTarget = null;
        DragCurrentMouse = null;
    }
}
