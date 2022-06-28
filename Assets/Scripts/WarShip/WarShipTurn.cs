using System.Collections;
using UnityEngine;

namespace SpaceMobile
{
    [RequireComponent(typeof(WarShip))]
    public class WarShipTurn : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Sprite _rollingSprite;
        [SerializeField] private Sprite _staySprite;


        private float _lastPositionX;

        private void Awake()
        {
            _lastPositionX = transform.position.x;
            StartCoroutine(Move());
        }

        IEnumerator Move()
        {
            while (true)
            {
                if (transform.position.x - _lastPositionX > 0)
                {
                    _spriteRenderer.sprite = _rollingSprite;
                    _spriteRenderer.flipX = true;
                }
                else if (transform.position.x - _lastPositionX < 0)
                {
                    _spriteRenderer.sprite = _rollingSprite;
                    _spriteRenderer.flipX = false;
                }
                else if (transform.position.x - _lastPositionX == 0)
                {
                    _spriteRenderer.sprite = _staySprite;
                }
                _lastPositionX = transform.position.x;
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
