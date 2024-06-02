namespace Subsetsix.Api.Entities;

public enum EntityStatus
{
    Active = 1,
    Archived = 0
}

public class EntityBase
{
    public Guid Id { get; init; }
    public EntityStatus Status { get; set; } = EntityStatus.Active;
    public DateTimeOffset AddedUtc { get; } = DateTimeOffset.UtcNow;
}

public class Item : EntityBase
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required List<string> Tags { get; set; }

    public void Apply(ItemAdded itemAdded)
    {
        Title = itemAdded.Title;
        Description = itemAdded.Description;
        Tags = itemAdded.Tags;
    }
}

public class ItemAdded
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required List<string> Tags { get; set; }
}