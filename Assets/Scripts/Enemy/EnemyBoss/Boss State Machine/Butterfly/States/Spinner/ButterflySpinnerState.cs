using System.Collections;
using UnityEngine;

namespace SpaceMobile
{
    [RequireComponent(typeof(ButterflySpinnerTransition))]
    public class ButterflySpinnerState : State
    {
        [SerializeField] private Bullet _bullet;
        [SerializeField] private Transform _firstSpinPoint;
        [SerializeField] private Transform _secondSpinPoint;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float fireRate;

        private bool _isFirstRotate;
        private bool _bothAttack;
        private float _firstDelayBetweenShots;
        private float _secondDelayBetweenShots;

        private void OnEnable()
        {
            _bothAttack = false;
            _isFirstRotate = true;
            StartCoroutine(Spin());
        }

        private void Update()
        {
            if (_isFirstRotate || _bothAttack)
            {
                _firstSpinPoint.rotation *= Quaternion.Euler(0, 0, _rotationSpeed * Time.deltaTime);
                if (Time.time > _firstDelayBetweenShots)
                {
                    _firstDelayBetweenShots = Time.time + fireRate / 3f;
                    Instantiate(_bullet, _firstSpinPoint.position, _firstSpinPoint.rotation);
                }
            }
            if (!_isFirstRotate || _bothAttack)
            {
                _secondSpinPoint.rotation *= Quaternion.Euler(0, 0, -_rotationSpeed * Time.deltaTime);
                if (Time.time > _secondDelayBetweenShots)
                {
                    _secondDelayBetweenShots = Time.time + fireRate / 3f;
                    Instantiate(_bullet, _secondSpinPoint.position, _secondSpinPoint.rotation);
                }
            }
        }

        private IEnumerator Spin()
        {
            yield return new WaitForSeconds(2f);
            _isFirstRotate = false;
            yield return new WaitForSeconds(2f);
            _bothAttack = true;
            yield return new WaitForSeconds(4f);
        }
    }
}
