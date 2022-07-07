using System.Collections;
using UnityEngine;

namespace SpaceMobile
{
    [RequireComponent(typeof(BeetleBulletsState))]
    public class BeetleBulletsTransition : Transition
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
