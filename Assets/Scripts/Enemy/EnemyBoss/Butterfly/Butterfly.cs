namespace SpaceMobile
{
    public class Butterfly : EnemyBoss, IDamageable
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
                //GameController.instance.BossDie();

                Destroy(gameObject);
            }
            //BossHealhBar.instance.SetHealth(Health);
        }
    }
}
