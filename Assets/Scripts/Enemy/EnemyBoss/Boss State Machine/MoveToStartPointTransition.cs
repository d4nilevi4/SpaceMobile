using UnityEngine;

namespace SpaceMobile
{
    [RequireComponent(typeof(MoveToStartPointState))]
    public class MoveToStartPointTransition : Transition
    {
        private Vector3 _targetPoint = new Vector3(0, 2.89f, 0);

        protected override void OnEnable()
        {
            base.OnEnable();
        }

        private void Update()
        {
            if (transform.position == _targetPoint)
                NeedTransit = true;
        }
    }
}
