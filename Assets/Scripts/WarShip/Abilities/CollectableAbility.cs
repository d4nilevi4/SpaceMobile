using UnityEngine;

namespace SpaceMobile
{
    public abstract class CollectableAbility : MonoBehaviour
    {
        public abstract void SetActiveAbility(WarShip player);
    }
}
