using UnityEngine;

namespace SpaceMobile
{
    public class ThunderCollectableAbility : CollectableAbility
    {
        private Mover _mover;
        private TouchableAbility _touchableAbility;

        private void Start()
        {
            _mover = GetComponent<Mover>();
            _touchableAbility = GetComponent<TouchableAbility>();
        }

        public override void SetActiveAbility(WarShip player)
        {
            _mover.StopMoving();
            Destroy(_mover);
            _touchableAbility.enabled = true;
            _touchableAbility.SetPlayer(player);
            Destroy(this);
        }
    }
}
