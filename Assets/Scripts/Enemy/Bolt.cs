using UnityEngine;

namespace SpaceMobile
{
    public class Bolt : MonoBehaviour
    {
        [SerializeField] private float _healValue;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out WarShip player))
            {
                player.Heal(_healValue);
                Destroy(gameObject);
            }
        }
    }
}
