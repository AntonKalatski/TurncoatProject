namespace Services.RaycastService.Interfaces
{
    public interface IInteractionManager
    {
        IInteractionState Current { get; }
    }
}