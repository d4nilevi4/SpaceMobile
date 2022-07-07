using UnityEngine;

namespace SpaceMobile
{
    public class ThunderTouchableAbility : TouchableAbility
    {
        [SerializeField] private ThunderAbility _thunder;

        private void OnMouseDown()
        {
            touchesCount++;
            Instantiate(_thunder, player.transform.GetChild(1).transform.position, Quaternion.identity);
            if (touchesCount == maxTouches)
                Destroy(gameObject);
        }

        private void Update()
        {
            
        }
    }
}
