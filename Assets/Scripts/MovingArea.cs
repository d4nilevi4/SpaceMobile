using System;
using UnityEngine;

namespace SpaceMobile
{
    [Serializable]
    public class Boundary
    {
        public float xMin, xMax, yMin, yMax;
    }

    public class MovingArea : MonoBehaviour
    {
        [SerializeField] private UIManager _UIManager;
        [SerializeField] private WarShip _warShip;
        [SerializeField] private Boundary _boundary;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private bool _gameIsStarted;

        private Camera _mainCamera;

        private void Start()
        {
            _mainCamera = Camera.main;
            _gameIsStarted = false;
        }

        public void OnMouseDrag()
        {
            if (_warShip == null) return;
            if (!_gameIsStarted)
            {
                _UIManager.StartGame();
                _gameIsStarted = true;
            }

            Vector3 mousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);

            mousePos.x = mousePos.x > _boundary.xMax ? _boundary.xMax : mousePos.x;
            mousePos.x = mousePos.x < _boundary.xMin ? _boundary.xMin : mousePos.x;

            mousePos.y = mousePos.y > _boundary.yMax ? _boundary.yMax : mousePos.y;
            mousePos.y = mousePos.y < _boundary.yMin ? _boundary.yMin : mousePos.y;

            _warShip.transform.position = Vector2.MoveTowards(_warShip.transform.position, new Vector2(mousePos.x, mousePos.y), _moveSpeed * Time.deltaTime);
        }
    }
}
