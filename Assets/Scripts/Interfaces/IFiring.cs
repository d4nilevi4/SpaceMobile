using UnityEngine;

namespace SpaceMobile
{
    public interface IFiring
    {
        Bullet BulletPrefab { get; set; }
        float ShotDelay { get; set; }
        float TimeAfterLastShot { get; set; }
        Transform FirstShotPoint { get; set; }
        Transform SecondShotPoint { get; set; }

        void Fire();
    }
}
