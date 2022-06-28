using UnityEngine;

namespace SpaceMobile
{
    public class Larva : MonoBehaviour
    {
        private WarShip _target;
        [SerializeField] private float _speed;
        [SerializeField] private float _lifeTime;
        [SerializeField] private float _damageValue;

        private void Start()
        {
            Destroy(gameObject, _lifeTime);
        }

        void FixedUpdate()
        {
            if (_target == null) return;

            Vector3 diff = _target.transform.position - transform.position;
            diff.Normalize();
            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
            transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _speed * Time.fixedDeltaTime);
        }

        public void SetTarget (WarShip target)
        {
            _target = target;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.TryGetComponent(out IDamageable hit))
            {
                hit.TakeDamage(_damageValue);
                Destroy(gameObject);
            }
        }
    }
}
