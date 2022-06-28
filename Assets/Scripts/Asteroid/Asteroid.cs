using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceMobile
{
    public class Asteroid : MonoBehaviour
    {
        [SerializeField] protected GameObject explosionEffect;
        [SerializeField] protected float maxHealth;

        [SerializeField] private float _damageByCollision;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IDamageable hit))
            {
                hit.TakeDamage(_damageByCollision);
                Destroy(gameObject);
            }
        }
    }
}
