using UnityEngine;

namespace SpaceMobile
{
    public class BoundaryZone : MonoBehaviour
    {
        [SerializeField] private LayerMask _layer;

        private void OnTriggerExit2D(Collider2D other)
        {
            Destroy(other.gameObject);
        }
    }
}
