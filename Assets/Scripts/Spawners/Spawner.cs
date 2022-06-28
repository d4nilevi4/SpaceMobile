using UnityEngine;

namespace SpaceMobile
{
    public abstract class Spawner : MonoBehaviour
    {
        [SerializeField] protected float startDelay;
        [SerializeField] protected float spawnDelay;

        protected float startTimer;
        protected float timeAfterLastSpawn;
        protected float scatterInX = 2.5f;

        private void OnEnable()
        {
            timeAfterLastSpawn = spawnDelay;
            startTimer = 0;
        }

        private void Update()
        {
            Spawn();
        }

        protected abstract void Spawn();
    }
}
