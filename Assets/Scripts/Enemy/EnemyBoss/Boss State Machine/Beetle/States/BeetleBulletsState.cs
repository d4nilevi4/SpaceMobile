using UnityEngine;

namespace SpaceMobile
{
    [RequireComponent(typeof(BeetleBulletsTransition))]
    public class BeetleBulletsState : State
    {
        [SerializeField] private Transform[] _leftSpawnPoints;
        [SerializeField] private Transform[] _rightSpawnPoints;
        [SerializeField] private LaserDone _leftBullets;
        [SerializeField] private LaserDone _rightBullets;

        private void OnEnable()
        {
            foreach (var spawnPoint in _leftSpawnPoints)
            {
                Instantiate(_leftBullets, spawnPoint.position, spawnPoint.rotation, transform);
            }

            foreach (var spawnPoint in _rightSpawnPoints)
            {
                Instantiate(_rightBullets, spawnPoint.position, spawnPoint.rotation, transform);
            }
        }
    }
}
