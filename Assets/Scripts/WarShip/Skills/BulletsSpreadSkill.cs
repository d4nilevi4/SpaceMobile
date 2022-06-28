using UnityEngine;

namespace SpaceMobile
{
    public class BulletsSpreadSkill : Skill
    {
        public override void ApplyBuff(WarShip player)
        {
            player.IncreaseShotsCount();
        }
    }
}
