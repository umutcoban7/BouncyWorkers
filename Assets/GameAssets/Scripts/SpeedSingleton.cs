using System;
using UnityEngine;
using UniRx;

namespace GameAssets.Scripts
{
    public class SpeedSingleton : MonoBehaviour
    {
        public static SpeedSingleton Instance { get; private set; }

        public FloatReactiveProperty speed = new(5);
        public FloatReactiveProperty maximumSpeed = new(12);
        [SerializeField] private float boostOffset = 7;

        [SerializeField] private float boostDurationMS = 400;
        private FloatReactiveProperty counter = new (0);

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
            UpdateMaximumSpeed();
            TemporarySpeedBoost();
        }

        void UpdateMaximumSpeed()
        {
            maximumSpeed.Subscribe(_ =>
            {
                maximumSpeed.Value = speed.Value + boostOffset;
            }).AddTo(gameObject);
        }

        
        //this could be in another script
        void TemporarySpeedBoost()
        {
            //INCREASING SPEED
            Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0)).Subscribe(_ =>
            {
                if (speed.Value < maximumSpeed.Value)
                {
                    speed.Value++;
                    counter.Value++;
                }
            }).AddTo(gameObject);

            //DECREASING SPEED
            Observable.Timer(TimeSpan.FromMilliseconds(boostDurationMS)).Where(_ => counter.Value > 0).Repeat().Subscribe(_ =>
            {
                counter.Value--;
                speed.Value--;
            }).AddTo(gameObject);
        }
    }
}