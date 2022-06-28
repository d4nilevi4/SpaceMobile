using System.Collections;
using UnityEngine;

namespace SpaceMobile
{
    [RequireComponent(typeof(ButterflyRainOfBombsState))]
    public class ButterflyRainOfBombsTransition : Transition
    {
        [SerializeField] private float _attackTime;

        protected override void OnEnable()
        {
            base.OnEnable();
            StartCoroutine(Transition());
        }

        IEnumerator Transition()
        {
            yield return new WaitForSeconds(_attackTime);
            NeedTransit = true;
        }
    }
}
