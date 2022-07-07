using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceMobile
{
    public class GalaxySpawner : Spawner
    {
        [SerializeField] private Mover[] _Galaxies;

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

                Mover galaxy = _Galaxies[Random.Range(0, _Galaxies.Length)];

                Instantiate(galaxy, spawnPositon, Quaternion.identity, transform);

                timeAfterLastSpawn = 0;
            }
        }
    }
}
