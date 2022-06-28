using System.Collections.Generic;
using UnityEngine;

namespace SpaceMobile
{
    [RequireComponent(typeof(BossStateMachine))]
    public abstract class State : MonoBehaviour
    {
        [SerializeField] private List<Transition> _transitions;

        protected WarShip Player { get; private set; }

        public void Enter(WarShip player)
        {
            if (!enabled)
            {
                Player = player;
                enabled = true;
                foreach (var transition in _transitions)
                {
                    transition.enabled = true;
                    transition.Init(Player);
                }
            }
        }

        public void Exit()
        {
            if (enabled)
            {
                foreach (var transition in _transitions)
                {
                    transition.enabled = false;
                }

                enabled = false;
            }
        }

        public State GetNextState()
        {
            foreach (var transition in _transitions)
                if (transition.NeedTransit)
                    return transition.TargetState;

            return null;
        }
    }
}
