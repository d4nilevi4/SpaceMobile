using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceMobile
{
    public class BackgroundRoll : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _middleSprite;

        [SerializeField] private float _speed = .5f;
        private float _positionMinY;
        private float _positionMaxY;
        private Vector2 _restartPosition;
        [SerializeField] private bool _downDirection;

        private void Awake()
        {
            _restartPosition = transform.position;
            _positionMinY = _middleSprite.bounds.size.y  - _restartPosition.y;
            _positionMaxY = _restartPosition.y - _middleSprite.bounds.size.y;
        }

        private void Update()
        {
            BackgroundScrolling(_downDirection);            
        }

        private void BackgroundScrolling(bool downDirection)
        {
            if (!downDirection)
            {
                transform.Translate(Vector3.down * _speed * Time.unscaledDeltaTime);
                if (transform.position.y <= -_positionMinY)
                {
                    transform.position = _restartPosition;
                }
            }
            else
            {
                transform.Translate(Vector3.up * _speed * Time.unscaledDeltaTime * 10f);
                if (transform.position.y >= -_positionMaxY)
                {
                    transform.position = _restartPosition;
                }
            }
        }

        public void SwapRollDirection()
        {
            _downDirection = true;
        }
    }
}
