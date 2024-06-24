namespace JohnnyDevCraft.Security.Module;

public interface IOwned
{
    public Guid OwnerId { get; set; }
}