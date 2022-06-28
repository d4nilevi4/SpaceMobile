using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace SpaceMobile
{
    public class EnemyBoss : MonoBehaviour
    {
        [SerializeField] protected float health;
        [SerializeField] private GameObject _attention;

        protected WarShip _player;

        public UnityAction BossDie;

        private void Awake()
        {
            _player = FindObjectOfType<WarShip>();
        }

        protected virtual void Init()
        {
             StartCoroutine(EmergenceBoss_Audio());
        }

        private void Start()
        {
            Init();
        } 

        public WarShip GetPlayer()
        {
            return _player;
        }

        private IEnumerator EmergenceBoss_Audio()
        {
            var alert = Instantiate(_attention, new Vector3(0, 0, 0), Quaternion.identity);
            //AudioManager.instance.PlayMusic(2, 0, 1);
            yield return new WaitForSeconds(4.85f);
            //AudioManager.instance.StopMusic(1);
            Destroy(alert);
        }
    }
}
