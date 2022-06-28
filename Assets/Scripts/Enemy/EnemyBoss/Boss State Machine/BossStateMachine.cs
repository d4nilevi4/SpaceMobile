using UnityEngine;

namespace SpaceMobile
{
    [RequireComponent(typeof(EnemyBoss))]
    public class BossStateMachine : MonoBehaviour
    {
        [SerializeField] private State _firstState;

        private WarShip _player;
        private State _currentState;

        public State CurrentState => _currentState;

        private void Start()
        {
            _player = GetComponent<EnemyBoss>().GetPlayer();

            Reset(_firstState);
        }

        private void Update()
        {
            if (_currentState == null)
                return;

            var nextState = _currentState.GetNextState();

            if (nextState != null)
                Transit(nextState);
        }

        private void Reset(State startState)
        {
            _currentState = startState;

            if (_currentState != null)
                _currentState.Enter(_player);
        }

        private void Transit(State nextState)
        {
            if (_currentState != null)
                _currentState.Exit();

            _currentState = nextState;

            if (_currentState != null)
                _currentState.Enter(_player);
        }
    }
}
