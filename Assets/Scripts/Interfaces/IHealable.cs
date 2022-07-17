namespace Interfaces
{
    public interface IHealable<T>
    {
        void Heal(T amount);
    }
}