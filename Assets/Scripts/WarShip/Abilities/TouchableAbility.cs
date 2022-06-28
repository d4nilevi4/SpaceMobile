using UnityEngine;

namespace SpaceMobile
{
    public abstract class TouchableAbility : MonoBehaviour
    {
        [SerializeField] protected int maxTouches;
        
        protected WarShip player;
        protected int touchesCount = 0;

        public void SetPlayer(WarShip player)
        {
            this.player = player;
        }
    }
}
