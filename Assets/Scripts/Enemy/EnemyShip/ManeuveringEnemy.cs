using System.Collections;
using UnityEngine;

namespace SpaceMobile
{
    [RequireComponent(typeof(EnemyShip))]
    public class ManeuveringEnemy : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        
        [SerializeField] private float _maneuveringSpeed;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            StartCoroutine(ManeuverEnemy());
        }

        private IEnumerator ManeuverEnemy()
        {
            float randomNumber;

            while (true)
            {
                randomNumber = Random.Range(0f, 10f);

                if (randomNumber < 3f && transform.position.x >= -2f)
                {
                    _rigidbody.velocity = new Vector2(0.8f, 1f) * _maneuveringSpeed;
                    yield return new WaitForSeconds(0.6f);
                    _rigidbody.velocity = new Vector2(0f, 1f) * _maneuveringSpeed;
                    yield return new WaitForSeconds(0.25f);
                }
                else if (randomNumber > 6f && transform.position.x <= 2f)
                {
                    _rigidbody.velocity = new Vector2(-0.8f, 1f) * _maneuveringSpeed;
                    yield return new WaitForSeconds(0.6f);
                    _rigidbody.velocity = new Vector2(0f, 1f) * _maneuveringSpeed;
                    yield return new WaitForSeconds(0.25f);

                }
                else
                {
                    _rigidbody.velocity = new Vector2(0f, 1f) * _maneuveringSpeed;
                    yield return new WaitForSeconds(0.3f);
                }
            }
        }
    }
}
