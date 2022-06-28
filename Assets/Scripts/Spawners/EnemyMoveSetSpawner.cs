using UnityEngine;

namespace SpaceMobile
{
    public class EnemyMoveSetSpawner : Spawner
    {
        [SerializeField] private EnemyMoveSet[] _MoveSets;

        public float SpawnDelay => spawnDelay;

        // ме гшашрэ ядекюрэ рюй врнаш лсбяерш ме онбрнпъкхяэ!!!!
        // лнбяерш хмнцдю онъбкъчряъ ндмнбпелеммн я аняянл

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
                EnemyMoveSet moveSet = _MoveSets[Random.Range(0, _MoveSets.Length)];

                Instantiate(moveSet, transform.position, Quaternion.identity, transform);
                
                timeAfterLastSpawn = 0;
            }
        }
    }
}
