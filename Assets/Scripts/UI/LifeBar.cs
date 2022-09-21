using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceMobile
{
    public class LifeBar : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _Lifes = new List<GameObject>();
        [SerializeField] private int _lifeCount;

        private void Start()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                _Lifes.Add(transform.GetChild(i).gameObject);
            }

            _lifeCount = transform.childCount - 1;
        }

        public void DecreaseLife()
        {
            _Lifes[_lifeCount--].SetActive(false);
        }
    }
}
