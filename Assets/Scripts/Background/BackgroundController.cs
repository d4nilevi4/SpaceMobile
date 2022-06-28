using System.Collections.Generic;
using UnityEngine;

namespace SpaceMobile
{
    public class BackgroundController : MonoBehaviour
    {
        [SerializeField] private WarShip _player;

        private List<BackgroundRoll> _Backgrounds = new List<BackgroundRoll>();

        [SerializeField] private ParticleSystem _starsGoDown;
        [SerializeField] private ParticleSystem _starsGoUp;

        private void OnEnable()
        {
            _player.PlayerDie += OnPlayerDie;
        }

        private void OnDisable()
        {
            _player.PlayerDie -= OnPlayerDie;
        }

        private void Start()
        {
            for (int i = 0; i < transform.childCount; i++)
                if (transform.GetChild(i).TryGetComponent(out BackgroundRoll backgrond))
                    _Backgrounds.Add(backgrond);

            _starsGoDown.gameObject.SetActive(true);
            _starsGoUp.gameObject.SetActive(false);
        }

        private void OnPlayerDie()
        {
            foreach (var background in _Backgrounds)
            {
                background.SwapRollDirection();
            }

            _starsGoDown.gameObject.SetActive(false);
            _starsGoUp.gameObject.SetActive(true);
        }
    }
}
