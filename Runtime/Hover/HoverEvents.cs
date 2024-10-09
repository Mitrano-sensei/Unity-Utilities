using System;
using UnityEngine;
using UnityEngine.Events;

namespace Utilities
{
    [Serializable] public class OnHoverEnter : UnityEvent<OnHoverEnterEvent> { }
    [Serializable] public class OnHoverExit : UnityEvent<OnHoverExitEvent> { }

    public class OnHoverEnterEvent
    {
        public float HoverEnterTime;
        public OnHoverEnterEvent()
        {
            HoverEnterTime = Time.time;
        }
    }

    public class OnHoverExitEvent
    {
        public float HoverExitTime;
        public float HoverEnterTime;

        public float HoverTime => HoverExitTime - HoverEnterTime;

        public OnHoverExitEvent(float hoverEnterTime)
        {
            HoverExitTime = Time.time;
            HoverEnterTime = hoverEnterTime;
        }
    }

    public class OnHoverEvent
    {
        public float StartTime;
        public float HoverDuration => Time.time - StartTime;
        public OnHoverEvent(float startTime)
        {
            StartTime = startTime;
        }
    }
}
