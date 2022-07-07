using UnityEngine;
using System.Collections;

namespace SpaceMobile
{
    [RequireComponent(typeof(BeetleLasersTransition))]
    public class BeetleLasersState : State
    {
        [SerializeField] private Transform[] _LasersPoints;
        [SerializeField] private GameObject _beetleLaser;
        [SerializeField] private float _prepearingTime;
        [SerializeField] private float _attackTime;

        private Animator _spiteAnimator;

        private void OnEnable()
        {
            _spiteAnimator = transform.GetChild(0).GetComponent<Animator>();
            _spiteAnimator.SetTrigger("PrepairLaserAttack");
            StartCoroutine(Attack());
        }

        private void Update()
        {
            
        }

        private IEnumerator Attack()
        {
            yield return new WaitForSeconds(_prepearingTime);
            foreach (var spawnPoint in _LasersPoints)
            {
                Instantiate(_beetleLaser, spawnPoint.position, spawnPoint.rotation, spawnPoint);
            }
            yield return new WaitForSeconds(_attackTime);
            _spiteAnimator.SetTrigger("LasserAttackDone");
        }
    }
}
