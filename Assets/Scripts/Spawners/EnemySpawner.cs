using UnityEngine;

namespace SpaceMobile
{
    public class EnemySpawner : Spawner
    {
        [SerializeField] private ManeuveringEnemy[] _Enemies;

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
                Vector2 spawnPositon = new Vector2(Random.Range(-scatterInX, scatterInX), transform.position.y);

                ManeuveringEnemy enemy = _Enemies[Random.Range(0, _Enemies.Length)];

                Instantiate(enemy, spawnPositon, Quaternion.identity, transform);

                timeAfterLastSpawn = 0;
            }
        }
    }
}
