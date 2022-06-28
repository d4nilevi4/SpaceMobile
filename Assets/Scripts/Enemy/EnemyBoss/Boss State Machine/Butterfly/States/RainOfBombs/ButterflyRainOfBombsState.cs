using System.Collections;
using UnityEngine;

namespace SpaceMobile
{
    [RequireComponent(typeof(ButterflyRainOfBombsTransition))]
    public class ButterflyRainOfBombsState : State
    {
        [SerializeField] private ButterflyBomb _butterflyBomb;
        [SerializeField] private int _bombsWavesCount;
        [SerializeField] private int _bombsInWave;
        [SerializeField] private float _timeBetweenSpawnBombs;

        private Vector3 _playerTempPosition;

        private void OnEnable()
        {
            StartCoroutine(Action());
        }

        IEnumerator Action()
        {
            for (int j = 0; j < _bombsWavesCount; j++)
            {
                _playerTempPosition = FindObjectOfType<WarShip>().transform.position;
                for (int i = 0; i < _bombsInWave; i++)
                {
                    var bomb = Instantiate(_butterflyBomb, transform.position, Quaternion.identity, gameObject.transform);
                    bomb.SetPlayerTempPosition(_playerTempPosition);
                    yield return new WaitForSeconds(_timeBetweenSpawnBombs);
                }

                yield return new WaitForSeconds(_timeBetweenSpawnBombs);
            }
        }
    }
}
