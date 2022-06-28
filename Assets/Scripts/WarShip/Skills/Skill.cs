using UnityEngine;

namespace SpaceMobile
{
    public abstract class Skill : MonoBehaviour
    {
        public abstract void ApplyBuff(WarShip player);
    }
}
