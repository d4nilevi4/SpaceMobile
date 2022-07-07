using UnityEngine;
using System.Collections;

namespace SpaceMobile
{
    [RequireComponent(typeof(BeetleLasersState))]
    public class BeetleLasersTransition : Transition
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
