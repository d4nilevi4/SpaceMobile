using UnityEngine;
using UnityEngine.Events;

namespace SpaceMobile
{
    public class BossSpawner : Spawner
    {
        [SerializeField] private EnemyBoss[] _Bosses;

        public UnityAction BossSpawn;

        // ме гшашрэ ядекюрэ рюй врнаш аняяш ме онбрнпъкхяэ!!!!

        protected override void Spawn()
        {
            if (startTimer <= startDelay)
            {
                startTimer += Time.deltaTime;
                return;
            }               

            timeAfterLastSpawn += Time.deltaTime;

            if (timeAfterLastSpawn >= spawnDelay)
            {
                EnemyBoss boss = _Bosses[Random.Range(0, _Bosses.Length)];

                Instantiate(boss, transform.position, Quaternion.identity, transform);

                BossSpawn?.Invoke();

                timeAfterLastSpawn = 0;
            }
        }
    }
}
