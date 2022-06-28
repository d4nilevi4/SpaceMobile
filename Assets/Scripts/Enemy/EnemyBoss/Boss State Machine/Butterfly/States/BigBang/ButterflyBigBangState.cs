using System.Collections;
using UnityEngine;

namespace SpaceMobile
{
    [RequireComponent(typeof(ButterflyBigBangTransition))]
    public class ButterflyBigBangState : State
    {
        [SerializeField] private Transform _laserPrepearingPoint;
        [SerializeField] private GameObject _laserPrepearing;
        [SerializeField] private GameObject _laserDoneParticles;
        [SerializeField] private GameObject _laserDangerousParticles;
        [SerializeField] private float _bangCount;
        [SerializeField] private float _bangDelay;

        private void OnEnable()
        {
            StartCoroutine(Laser());
        }

        IEnumerator Laser()
        {
            Instantiate(_laserPrepearing, _laserPrepearingPoint.position, Quaternion.identity, transform);
            yield return new WaitForSeconds(3f);
            Instantiate(_laserDoneParticles, _laserPrepearingPoint.position, Quaternion.identity, transform);
            for (int i = 0; i < _bangCount; i++)
            {
                Instantiate(_laserDangerousParticles, _laserPrepearingPoint.position, Quaternion.identity);
                yield return new WaitForSeconds(_bangDelay);
            }
        }
    }
}
