using UnityEngine;

namespace SpaceMobile
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BulletMover : MonoBehaviour
    {
        [SerializeField] private float _laserSpeed;
        private Rigidbody2D _rigidbody;

        void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _rigidbody.velocity = _rigidbody.transform.up * _laserSpeed;
        }
    }
}
