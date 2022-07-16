using UnityEngine;

namespace Interfaces
{
    public interface IDamageable<T>
    {
        void Damage(T damage);
        void Damage(T damage, Collision hitResult);
    }
}