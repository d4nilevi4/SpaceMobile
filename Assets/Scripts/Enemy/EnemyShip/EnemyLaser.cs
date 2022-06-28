using UnityEngine;

namespace SpaceMobile
{
    public class EnemyLaser : MonoBehaviour
    {
        [SerializeField] private float _damageValue;
        [SerializeField] private float _lifeTime;

        private void Start()
        {
            if (_lifeTime != 0)
            {
                Destroy(gameObject, _lifeTime);
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.TryGetComponent(out IDamageable hit))
                hit.TakeDamage(_damageValue);
        }
    }
}
