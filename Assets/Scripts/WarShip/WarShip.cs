using UnityEngine;
using System.Collections;
using UnityEngine.Events;

namespace SpaceMobile
{
    public class WarShip : MonoBehaviour, IDamageable
    {
        [SerializeField] private AudioManager _audioManager;

        [Header("Health")]
        [SerializeField] private float _maxHealth;
        [SerializeField] private HealthBar _healthBar;

        [Header("Fire")]
        [SerializeField] private Transform[] _shotSapwnPoints;
        [SerializeField] private Bullet _bolt;
        [SerializeField] private int _shotsCount = 1;
        [SerializeField] private float _fireRate;
        private float _timeAfterLastSoot;

        public float Health { get; set; }

        public event UnityAction PlayerDie;

        private void Start()
        {
            Health = _maxHealth;
            _healthBar.SetMaxHealth(_maxHealth);
        }

        private void Update()
        {
            Fire();
        }

        private void Fire()
        {
            _timeAfterLastSoot += Time.deltaTime;

            if ( _timeAfterLastSoot >= _fireRate)
            { 
                for (int i = 0; i < _shotsCount; i++)
                {
                    Instantiate(_bolt, _shotSapwnPoints[i].position, _shotSapwnPoints[i].rotation);
                }
                _audioManager.PlayMusic(3);
                _timeAfterLastSoot = 0;
            }
        }

        public void Heal(float healValue)
        {
            if (Health >= _maxHealth) return;
            Health += healValue;
            _healthBar.SetHealth(Health);
        }

        public void TakeDamage(float damageValue)
        {
            Handheld.Vibrate();
            Health -= damageValue;
            if (Health <= 0)
            {
                PlayerDie?.Invoke();
                Destroy(gameObject);
            }
            DecreaseShotsCount();
            _healthBar.SetHealth(Health);
        }

        public void IncreaseFireRate(float value, float time)
        {
            StartCoroutine(ChangeFireRate(value, time));
        }

        private IEnumerator ChangeFireRate(float value, float time)
        {
            _fireRate /= value;
            yield return new WaitForSeconds(time);
            _fireRate *= value;
        }

        public void IncreaseShotsCount()
        {
            if (_shotsCount >= 5)
                return;

            _shotsCount += 2;
        }

        private void DecreaseShotsCount()
        {
            if (_shotsCount == 1)
                return;

            _shotsCount -= 2;
        }
    }
}
