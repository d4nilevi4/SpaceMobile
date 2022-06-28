using UnityEngine;

namespace SpaceMobile
{
    [RequireComponent(typeof(ButterflyKafunTransition))]
    public class ButterflyKafunState : State
    {
        [SerializeField] private LaserDone _kafunParticles;
        [SerializeField] private float _speed;

        private Animator _animator;

        private void OnEnable()
        {
            _animator = GetComponent<Animator>();
            _animator.SetTrigger("Kafun");
            Instantiate(_kafunParticles, transform.position, Quaternion.identity, transform);
        }
    }
}
