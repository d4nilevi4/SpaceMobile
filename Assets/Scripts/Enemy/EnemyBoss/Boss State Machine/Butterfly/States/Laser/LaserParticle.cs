using UnityEngine;

namespace SpaceMobile
{
    public class LaserParticle : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _speedDestroy;
        [SerializeField] private float _destroyTime;
        
        private int _offset;
        private float _radius;

        private void Start()
        {
            Destroy(gameObject, _destroyTime);
        }

        private void Update()
        {
            transform.position = new Vector2(Mathf.Cos(30 * (Time.time - _offset * 2) * _speed) - Mathf.Cos((Time.time - _offset * 2) * _speed), Mathf.Sin(30 * (Time.time - _offset * 2) * _speed) - Mathf.Sin((Time.time - _offset * 2) * _speed)) * _radius + new Vector2(0, 1.5f);
            _radius = Mathf.MoveTowards(_radius, 0, _speedDestroy * Time.deltaTime);
            _speed = Mathf.MoveTowards(_speed, _speed * 5, _speedDestroy * Time.deltaTime / 1000);
        }

        public void SetOffset(int offset)
        {
            _offset = offset;
        }

        public void SetRadius(float radius)
        {
            _radius = radius;
        }
    }
}
