using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceMobile
{
    public class EnemyShip : MonoBehaviour
    {
        //private UIController _UIController;
        [SerializeField] private GameObject _explosionParticlePrefab;
        [SerializeField] protected GameObject hitEnemyParticlePrefab;
        [SerializeField] private float _damageByCollision;

        [Header("Shards")]
        [SerializeField] private Bolt[] _Bolts;
        [SerializeField] private int _maxBoltsCount;

        [Header("Health")]
        [SerializeField] protected float heath;
        [SerializeField] private float _increaseValue;
        [SerializeField] private float _distanceForIncrease;
        //private int _increaseCount = 1;

        protected virtual void Init()
        {
            //_UIController = FindObjectOfType<UIController>().GetComponent<UIController>();
        }

        private void Start()
        {
            Init();
        }

        protected virtual void Update()
        {
            // Вызывает метод уеличения Хп каждые _distanceForIncrease очков
            //if (_UIController.Distance > _distanceForIncrease * _increaseCount) IncreaseHealth();
        }

        // Увеличивает количество хп в _increaseValue раз
        //private void IncreaseHealth()
        //{
        //    _increaseCount++;
        //    heath *= _increaseValue;
        //}

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IDamageable hit))
            {
                hit.TakeDamage(_damageByCollision);
                Die();
            }
        }

        protected void Die()
        {
            Instantiate(_explosionParticlePrefab, this.transform.position, Quaternion.identity);
            SpawnBolts();

            Destroy(this.gameObject);
        }

        private void SpawnBolts()
        {
            var boltsCount = Random.Range(0, _maxBoltsCount);

            for (int i = 0; i < boltsCount; i++)
            {
                Instantiate(_Bolts[Random.Range(0, _Bolts.Length - 1)],
                    new Vector3(transform.position.x + Random.Range(0.2f, 1f),
                    transform.position.y + Random.Range(0.2f, 1f),
                    transform.position.z),
                    Quaternion.identity);
            }
        }
    }
}
