namespace CarMk.Core.Shared.Entities;

public abstract class BaseEntitiy
{
    protected BaseEntitiy()
    {
        Id = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
        CreatedAt = DateTime.UtcNow;
    }

    public string Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    public void SetUpdatedAt()
    {
        UpdatedAt = DateTime.UtcNow;
    }
}