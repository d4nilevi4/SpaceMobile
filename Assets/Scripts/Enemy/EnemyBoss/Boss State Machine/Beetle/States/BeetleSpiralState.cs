using UnityEngine;

namespace SpaceMobile
{
    [RequireComponent(typeof(BeetleSpiralTransition))]
    public class BeetleSpiralState : State
    {
        [SerializeField] private LaserDone _spiral;
        [SerializeField] private Transform _spawnPoint;

        private void OnEnable()
        {
            Instantiate(_spiral, _spawnPoint.position, Quaternion.identity, transform);
        }

        private void Update()
        {
            
        }
    }
}
