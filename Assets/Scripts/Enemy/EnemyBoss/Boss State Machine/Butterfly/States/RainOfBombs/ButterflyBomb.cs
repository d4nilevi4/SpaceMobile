using UnityEngine;

namespace SpaceMobile
{
    public class ButterflyBomb : MonoBehaviour
    {
        [SerializeField] private float _yForceFloat;
        [SerializeField] private float _xForceFloat;
        [SerializeField] private float _damageValue;
        private Vector3 _playerTempPosition = new Vector3(0f, 0f, 0f);
        private float _xTemp;

        void Start()
        {
            // Выберает рандомно силу по Х //
            //_xTemp = Random.Range(-_xForceFloat, _xForceFloat);
            _xTemp = _playerTempPosition.x * 25f;
            AddForceBomb();
        }

        private void AddForceBomb()
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(_xTemp, _yForceFloat));
        }

        public void SetPlayerTempPosition(Vector3 tempPosition)
        {
            _playerTempPosition = tempPosition;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IDamageable hit))
            {
                hit.TakeDamage(_damageValue);
                Destroy(gameObject);
            }
        }
    }
}
