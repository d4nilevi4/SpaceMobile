using System.Collections;
using UnityEngine;

namespace SpaceMobile
{
    [RequireComponent(typeof(ButterflyLaserTransition))]
    public class ButterflyLaserState : State
    {
        [SerializeField] private EnemyLaser _laser;
        [SerializeField] private Transform _laserPrepearingPoint;
        [SerializeField] private GameObject _laserPrepearing;
        [SerializeField] private GameObject _laserDone;

        private Vector3 _laserPoint = new Vector3(0.03f, -2f, 0f);


        private void OnEnable()
        {
            StartCoroutine(Laser());
        }

        IEnumerator Laser()
        {
            Instantiate(_laserPrepearing, _laserPrepearingPoint.position, Quaternion.identity, transform);
            yield return new WaitForSeconds(3f);
            Instantiate(_laser, _laserPoint, Quaternion.identity, transform);
            Instantiate(_laserDone, _laserPrepearingPoint.position, Quaternion.identity, transform);
        }
    }
}
