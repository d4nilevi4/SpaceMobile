using System.Collections.Generic;
using UnityEngine;

namespace SpaceMobile
{
    public class LaserPreparation : MonoBehaviour
    {
        [SerializeField] private LaserParticle _laserParticle;
        [SerializeField] private int _particlesCount;
        [SerializeField] private float _radius;

        private List<LaserParticle> _laserParticles = new List<LaserParticle>();

        private void Start()
        {
            for (int i = 0; i < _particlesCount; i++)
            {
                _laserParticles.Add(Instantiate(_laserParticle, transform.position, Quaternion.identity, transform));
                _laserParticles[i].SetOffset(i);
                _laserParticles[i].SetRadius(_radius);
            }
        }
    }
}
