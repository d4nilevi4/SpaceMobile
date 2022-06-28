using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

namespace SpaceMobile
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private WarShip _player;

        [Header("Pause Menu")]
        [SerializeField] private GameObject _pauseMenu;
        [SerializeField] private GameObject _pauseButton;
        [SerializeField] private AudioMixerSnapshot _pausedSnapshot;
        [SerializeField] private AudioMixerSnapshot _unPausedSnapshot;

        [Header("GameOver Menu")]
        [SerializeField] private GameOverMenu _gameOverMenu;
        [SerializeField] private float _timeAfterGameOverPanel;

        [Header("Start Menu")]
        [SerializeField] private StartMenu _startMenu;
        [SerializeField] private GameObject _healthBar;
        [SerializeField] private Score _score;

        private void OnEnable()
        {
            _player.PlayerDie += OnPlayerDie;
        }

        private void OnDisable()
        {
            _player.PlayerDie -= OnPlayerDie;
        }

        public void StartGame()
        {
            Time.timeScale = 1f;
            _startMenu.gameObject.SetActive(false);
            _healthBar.SetActive(true);
            _pauseButton.SetActive(true);
            _score.gameObject.SetActive(true);
        }

        public void EnablePauseMenu()
        {
            Time.timeScale = 0f;
            _pausedSnapshot.TransitionTo(0.0001f);
            _pauseButton.SetActive(false);
            _pauseMenu.SetActive(true);
        }

        public void DisablePauseMenu()
        {
            Time.timeScale = 1f;
            _unPausedSnapshot.TransitionTo(0.0001f);
            _pauseButton.SetActive(true);
            _pauseMenu.SetActive(false);
        }

        private void OnPlayerDie()
        {
            StartCoroutine(EnableGameOverPanel());
        }

        private IEnumerator EnableGameOverPanel()
        {
            yield return new WaitForSeconds(_timeAfterGameOverPanel);
            _gameOverMenu.gameObject.SetActive(true);
        }
    }
}
