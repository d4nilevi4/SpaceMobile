using System.Collections;
using UnityEngine;

namespace SpaceMobile
{
    [RequireComponent(typeof(ButterflyLarvaTransition))]
    public class ButterflyLarvaState : State
    {
        [SerializeField] private Larva _larva;
        [SerializeField] private int _larvaCount;

        private void OnEnable()
        {
            StartCoroutine(Action());
        }

        IEnumerator Action()
        {
            for (int i = 0; i < _larvaCount; i++)
            {
                var larva = Instantiate(_larva,
                            new Vector3(transform.position.x + Random.Range(-2, 2),
                                        transform.position.y + Random.Range(-2, 2),
                                        transform.position.z),
                            Quaternion.identity, gameObject.transform);

                larva.SetTarget(Player);
                yield return new WaitForSeconds(0.05f);
            }
        }
    }
}
