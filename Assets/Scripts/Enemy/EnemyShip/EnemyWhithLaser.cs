using UnityEngine;

namespace SpaceMobile
{
    public class EnemyWhithLaser : EnemyShip, IDamageable
    {
        public float Health { get; set; }

        protected override void Init()
        {
            Health = heath;
            base.Init();
        }

        public void TakeDamage(float damageValue)
        {
            Health -= damageValue;
            Instantiate(hitEnemyParticlePrefab, new Vector3(transform.position.x, transform.position.y, -1f), Quaternion.identity);
            if (Health <= 0)
            {
                Die();
            }
        }
    }
}
