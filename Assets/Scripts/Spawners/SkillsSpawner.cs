using UnityEngine;

namespace SpaceMobile
{
    public class SkillsSpawner : Spawner
    {
        [SerializeField] private Skill[] _Skills;

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

                Skill skill = _Skills[Random.Range(0, _Skills.Length)];

                Instantiate(skill, spawnPositon, Quaternion.identity, transform);

                timeAfterLastSpawn = 0;
            }
        }
    }
}
