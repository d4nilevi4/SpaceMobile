using UnityEngine;

namespace SpaceMobile
{
    public class WarShipAbilitiesController : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private Vector3 _abilityPosition;
        [SerializeField] private float _abilityScaleMultiplier;
         
        private WarShip _player;

        private void Start()
        {
            _player = GetComponent<WarShip>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out CollectableAbility ability))
            {
                ability.SetActiveAbility(_player);
                ReplaceAbility(ability);
            }
        }

        private void ReplaceAbility(CollectableAbility ability)
        {
            ability.transform.parent = _camera.transform;
            ability.transform.localScale = Vector3.one * _abilityScaleMultiplier;
            ability.transform.localPosition = _abilityPosition;
        }
    }    
}
