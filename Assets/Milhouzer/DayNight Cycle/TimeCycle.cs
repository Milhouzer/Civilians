using System;
using UnityEngine;

namespace Milhouzer.DayNightCycle
{
    public class TimeCycle : MonoBehaviour
    {
        [SerializeField]
        private float realTimeTickDuration;
        [SerializeField]
        private float tickAmount;

        private float tickTimer;
        private int Tick;

        public delegate void TickDelegate(DateTime time);
        public static event TickDelegate OnTick;

        private DateTime now;
        public DateTime Now { get => now; }

        private void Start() 
        {
            now = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
        }

        void Update()
        {
            tickTimer += Time.deltaTime;
            if(tickTimer > realTimeTickDuration)
            {
                tickTimer -= realTimeTickDuration;
                Tick++;

                now = now.AddMinutes(tickAmount);
                OnTick?.Invoke(now);
            }
        }
    }
}
