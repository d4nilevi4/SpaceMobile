using UnityEngine;

namespace SpaceMobile
{
    public class EnemyWithGuns : EnemyShip, IDamageable, IFiring
    {
        [Header("Fire")]
        [SerializeField] private Bullet _bullet;
        [SerializeField] private float _shotDelay;
        [SerializeField] private Transform _firstShotPoint;
        [SerializeField] private Transform _secondShopPoint;
        private bool _secondShot;

        public float Health { get; set; }
        public Bullet BulletPrefab { get; set; }
        public float ShotDelay { get; set; }
        public float TimeAfterLastShot { get; set; }
        public Transform FirstShotPoint { get; set; }
        public Transform SecondShotPoint { get; set; }

        protected override void Init()
        {
            base.Init();

            Health = heath;
            BulletPrefab = _bullet;
            ShotDelay = _shotDelay;
            FirstShotPoint = _firstShotPoint;
            SecondShotPoint = _secondShopPoint;
        }

        protected override void Update()
        {
            base.Update();
            Fire();
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

        public void Fire()
        {
            if (TimeAfterLastShot >= ShotDelay)
            {
                if (_secondShot)
                {
                    Instantiate(BulletPrefab, FirstShotPoint.position, FirstShotPoint.rotation);
                    _secondShot = true;
                }
                else
                {
                    Instantiate(BulletPrefab, SecondShotPoint.position, SecondShotPoint.rotation);
                    _secondShot = false;
                }
                TimeAfterLastShot = 0;
            }
            TimeAfterLastShot += Time.deltaTime;
        }
    }
}
