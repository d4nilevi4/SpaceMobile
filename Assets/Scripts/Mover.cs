using UnityEngine;

namespace SpaceMobile
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Mover : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Rigidbody2D _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _rigidbody.velocity = Vector3.up * _speed;
        }

        public void StopMoving()
        {
            _rigidbody.velocity = Vector3.zero;
        }
    }
}
