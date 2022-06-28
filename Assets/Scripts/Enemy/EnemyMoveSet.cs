using UnityEngine;

namespace SpaceMobile
{
    public class EnemyMoveSet : MonoBehaviour
    {
        [SerializeField] private float _lifeTime = 10f;

        private void Start()
        {
            if (transform.parent.TryGetComponent(out EnemyMoveSetSpawner spawner))
                _lifeTime = spawner.SpawnDelay;

            Destroy(gameObject, _lifeTime);
        }
    }
}
