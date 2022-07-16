using UnityEngine;

namespace Interfaces
{
    public interface IDamageable<T>
    {
        void Damage(T damage);

        //void Damage(T damage, Collision hitResult);
        void Damage(float damage, Vector3 impactForce, Vector3 impactPoint);
    }
}