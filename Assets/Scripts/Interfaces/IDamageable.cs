namespace Interfaces
{
    public interface IDamageable<T>
    {
        void Damage(T damageTaken);
    }
}