namespace RayCaster
{
    public interface IRaycastBehaviourFactory
    {
        IRaycastBehaviour Create(string key);
    }
}