using UnityEngine;

namespace SpaceMobile
{
    public class LaserDone : MonoBehaviour
    {
        [SerializeField] private float _damageValue;

        private void OnParticleCollision(GameObject other)
        {
            if (other.TryGetComponent(out IDamageable hit))
                hit.TakeDamage(_damageValue);
        }
    }
}
