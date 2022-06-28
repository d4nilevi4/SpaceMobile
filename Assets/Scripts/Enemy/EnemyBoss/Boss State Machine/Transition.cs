using UnityEngine;

namespace SpaceMobile
{
    [RequireComponent(typeof(State))]
    public abstract class Transition : MonoBehaviour
    {
        [SerializeField] private State _targetState;

        protected WarShip Player { get; private set; }

        public State TargetState => _targetState;

        public bool NeedTransit { get; protected set; }

        public void Init(WarShip player)
        {
            Player = player;
        }

        protected virtual void OnEnable()
        {
            NeedTransit = false;
        }
    }
}
