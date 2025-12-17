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

    public void SetSize(GridSize newSize)
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

    public virtual void Resize(GridSize newSize)
    {
        Size = newSize;
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
        $"ID: {Id}, Posición: {Position}, Tamaño: {Size}";

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public GridObject GetLargerObject(GridObject other, Direction direction)
    {
        GridObject result = this;

        if (direction == Direction.Up || direction == Direction.Down)
        {
            if (other.Size.Height > this.Size.Height)
            {
                result = other;
            }
        }
        else if (direction == Direction.Left || direction == Direction.Right)
        {
            if (other.Size.Width > this.Size.Width)
            {
                result = other;
            }
        }
        else if (direction == Direction.UpLeft || direction == Direction.UpRight ||
                 direction == Direction.DownLeft || direction == Direction.DownRight)
        {
            // Compare vertical first, then horizontal
            if (other.Size.Height > this.Size.Height)
            {
                result = other;
            }
            else if (other.Size.Height == this.Size.Height && other.Size.Width > this.Size.Width)
            {
                result = other;
            }
        }

        return result;
    }

    public bool BiggerThan(GridObject other)
    {
        int thisArea = this.Size.Width * this.Size.Height;
        int otherArea = other.Size.Width * other.Size.Height;

        bool result = thisArea > otherArea;
        return result;
    }

    public GridObject GetRealObject()
    {
        return IsEmptyObject() ? null : this;
    }
}