namespace SpaceMobile
{
    public interface IDamageable
    {
        float Health { get; set; }
        void TakeDamage(float damageValue);
    }
}
