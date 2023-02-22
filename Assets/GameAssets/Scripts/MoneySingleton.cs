using System;
using UniRx;
using UnityEngine;

namespace GameAssets.Scripts
{
    public class MoneySingleton : MonoBehaviour
    {
        public static MoneySingleton Instance { get; private set; }

        public FloatReactiveProperty currentMoney = new(10);
        public float passiveIncome = 10;
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }

        private void Start()
        {
            Observable.Interval(TimeSpan.FromMilliseconds(1000)).Subscribe(l =>
            {
                currentMoney.Value += passiveIncome;
            }).AddTo(gameObject);
        }
    }
}
