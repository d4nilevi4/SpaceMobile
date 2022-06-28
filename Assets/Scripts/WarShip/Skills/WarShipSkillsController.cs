using UnityEngine;

namespace SpaceMobile
{
    public class WarShipSkillsController : MonoBehaviour
    {
        private WarShip _player;

        private void Start()
        {
            _player = GetComponent<WarShip>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.TryGetComponent(out Skill skill))
            {
                skill.ApplyBuff(_player);
                Destroy(skill.gameObject);
            }
        }
    }
}
