using UnityEngine;
using System.Collections.Generic;

namespace SpaceMobile
{
    public class SpawnersController : MonoBehaviour
    {
        [SerializeField] private AudioManager _audioManager;
        [SerializeField] private WarShip _player;
        [SerializeField] private BossSpawner _bossSpawner;
        private EnemyBoss _currentBoss;

        private List<Spawner> _Spawners = new List<Spawner>();

        private void OnEnable()
        {
            _player.PlayerDie += OnPlayerDie;
            _bossSpawner.BossSpawn += OnBossSpawn;
        }

        private void OnDisable()
        {
            _player.PlayerDie -= OnPlayerDie;
            _bossSpawner.BossSpawn -= OnBossSpawn;
        }

        private void Start()
        {
            for (int i = 0; i < transform.childCount; i++)
                _Spawners.Add(transform.GetChild(i).GetComponent<Spawner>());
        }

        private void OnPlayerDie()
        {
            DisableSpawners(true);
        }

        private void OnBossSpawn()
        {
            DisableSpawners();
            _audioManager.PlayMusic(2, 0, 1);
            _currentBoss = FindObjectOfType<EnemyBoss>();
            _currentBoss.BossDie += OnBossDie;
        }

        private void DisableSpawners(bool destroyObjectsInEachSpawners = false)
        {
            foreach (var spawner in _Spawners)
            {
                if (destroyObjectsInEachSpawners)
                {
                    for (int i = 0; i < spawner.transform.childCount; i++)
                    {
                        Destroy(spawner.transform.GetChild(i).gameObject);
                    }
                }
                spawner.enabled = false;
            }
        }

        private void EnableSpawners()
        {
            foreach(var spawner in _Spawners)
            {
                spawner.enabled = true;
            }
        }

        private void OnBossDie()
        {
            EnableSpawners();
            _audioManager.PlayMusic(0, 2);
            _currentBoss.BossDie -= OnBossDie;
        }
    }
}
