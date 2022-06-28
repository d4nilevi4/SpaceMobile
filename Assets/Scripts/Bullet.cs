using UnityEngine;

namespace SpaceMobile
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _damageValue;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IDamageable hit))
            {
                hit.TakeDamage(_damageValue);
                Destroy(gameObject);
            }
        }
    }
}
