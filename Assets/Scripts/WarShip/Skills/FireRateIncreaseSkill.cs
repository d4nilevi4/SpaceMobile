using UnityEngine;

namespace SpaceMobile
{
    public class FireRateIncreaseSkill : Skill
    {
        [SerializeField] private float _time;
        [SerializeField] private float _magnificationValue;

        public override void ApplyBuff(WarShip player)
        {
            player.IncreaseFireRate(_magnificationValue, _time);
        }
    }
}
