namespace Services.RaycastService.Interfaces
{
    public interface IInteractionStateFactory
    {
        IInteractionState Create(string key);
    }
}