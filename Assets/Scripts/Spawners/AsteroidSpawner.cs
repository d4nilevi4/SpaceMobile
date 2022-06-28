using UnityEngine;

namespace SpaceMobile
{
    public class AsteroidSpawner : Spawner
    {
        [SerializeField] private Asteroid[] _Asteroids;
        
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

                Asteroid asteroid = _Asteroids[Random.Range(0, _Asteroids.Length)];

                Instantiate(asteroid, spawnPositon, Quaternion.identity, transform);

                timeAfterLastSpawn = 0;
            }
        }
    }
}
