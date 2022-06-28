using UnityEngine;
using UnityEngine.UI;
using System;

namespace SpaceMobile
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private float _cuurentScore;
        [SerializeField] private BossSpawner _bossSpawner;
        [SerializeField] private WarShip _player;

        private EnemyBoss _currentBoss;
        private bool _isDisableCounter = false;
        private Text _scoreText;

        private void OnEnable()
        {
            _bossSpawner.BossSpawn += OnBossSpawn;
            _player.PlayerDie += OnPlayerDie;
        }

        private void OnDisable()
        {
            _bossSpawner.BossSpawn -= OnBossSpawn;
            _player.PlayerDie -= OnPlayerDie;
        }

        public float CurrentScore => _cuurentScore;

        private void Start()
        {
            _scoreText = GetComponent<Text>();
        }

        private void Update()
        {
            if (!_isDisableCounter)
            {
                _cuurentScore += Time.deltaTime;
                _scoreText.text = "Score: " + Convert.ToInt32(_cuurentScore);
            }
        }

        private void OnBossSpawn()
        {
            _isDisableCounter = true;
            _currentBoss = FindObjectOfType<EnemyBoss>();
            _currentBoss.BossDie += OnBossDie;
        }

        private void OnBossDie()
        {
            _isDisableCounter = false;
            _currentBoss.BossDie -= OnBossDie;
        }

        private void OnPlayerDie()
        {
            _isDisableCounter = true;
        }
    }
}
