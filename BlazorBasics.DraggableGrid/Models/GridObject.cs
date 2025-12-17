namespace BlazorBasics.DraggableGrid.Models;

public abstract class GridObject
{
    private string IdBF;
    public string Id
    {
        get
        {
            return GetId();
        }
        private set
        {
            IdBF = value;
        }
    }
    public GridPosition Position { get; protected set; }
    public GridSize Size { get; protected set; }

    internal GridObject(string id, GridPosition position, GridSize size)
    {
        IdBF = string.IsNullOrWhiteSpace(id) ? Guid.NewGuid().ToString() : id;
        Position = position;
        Size = size;
    }

    public void Resize(GridSize newSize)
    {
        Size = newSize;
    }

    public bool CanReplace(GridObject other, GridPosition newPosition)
    {
        return other.Id != this.Id &&
            this.Size.Width == other.Size.Width &&
            this.Size.Height == other.Size.Height &&
            newPosition.Column == other.Position.Column &&
            newPosition.Row == other.Position.Row;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not GridObject other)
            return false;
        return other.Id == this.Id;
    }

    public virtual void MoveTo(GridPosition newPosition)
    {
        Position = newPosition;
    }

    public bool IsEmptyObject() =>
        IdBF.Substring(0, 1).Equals("_");

    private string GetId()
    {
        string id = IdBF;
        if (IsEmptyObject())
        {
            id = IdBF.Substring(1);
        }
        return id;
    }

    public override string ToString() =>
        $"ID: {Id}, Position: {Position}, Size: {Size}";

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}