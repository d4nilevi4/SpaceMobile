using UnityEngine;

namespace SpaceMobile
{
    public class BlackAsteroid : Asteroid, IDamageable
    {
        public float Health { get ; set ; }

        private void Start()
        {
            Health = maxHealth;
        }

        public void TakeDamage(float damageValue)
        {
            Health -= damageValue;
            if (Health <= 0)
            {
                Instantiate(explosionEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
