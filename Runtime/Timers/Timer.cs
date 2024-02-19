using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{
    public abstract class Timer
    {
        protected float _initialTime;
        protected float Time { get; set; }
        public bool IsRunning { get; protected set; }

        public Action OnTimerStart = delegate { };
        public Action OnTimerStop = delegate { };

        public Timer(float time)
        {
            _initialTime = time;
            IsRunning = false;
        }

        public void Start()
        {
            Time = _initialTime;
            if (!IsRunning)
            {
                IsRunning = true;
                OnTimerStart();
            }
        }

        public void Stop()
        {
            if (IsRunning)
            {
                IsRunning = false;
                OnTimerStop();
            }

        }

        public void Resume() => IsRunning = true;
        public void Pause() => IsRunning = false;

        public abstract void Tick(float deltaTime);
    }
}