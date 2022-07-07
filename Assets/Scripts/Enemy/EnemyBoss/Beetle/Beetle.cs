namespace SpaceMobile
{
    public class Beetle : EnemyBoss, IDamageable
    {
        public float Health { get; set; }

        protected override void Init()
        {
            base.Init();
            Health = health;
            //BossHealhBar.instance.SetMaxHealth(Health);
        }

        public void TakeDamage(float damageValue)
        {
            Health -= damageValue;

            if (Health <= 0)
            {
                Health = 0;
                BossDie?.Invoke();

                Destroy(gameObject);
            }
            //BossHealhBar.instance.SetHealth(Health);
        }
    }
}
