using System;
using UnityEngine;
using UnityEngine.Events;

namespace Utilities
{
    [RequireComponent(typeof(Collider2D))]
    public class Hoverable2D : MonoBehaviour
    {
        [Header("Events")]
        [SerializeField] private OnHoverEnter _onHoverEnter = new();
        [SerializeField] private OnHoverExit _onHoverExit = new();

        private HoverState _hoverState = HoverState.None;

        private float _hoverEnterTime;

        public UnityAction<OnHoverEnterEvent> OnHoverEnter;
        public UnityAction<OnHoverEvent> OnHover;
        public UnityAction<OnHoverExitEvent> OnHoverExit;

        public bool IsHovered => _hoverState == HoverState.Hovered;

        public void Start()
        {
            _hoverState = HoverState.None;
            //_onHoverEnter.AddListener(e => Debug.Log("Hover Enter"));
            //_onHoverExit.AddListener(e => Debug.Log("Hover Exit"));
        }

        void Update()
        {
            switch (_hoverState)
            {
                case HoverState.None:
                    if (CheckHover())
                        _hoverState = HoverState.HoverEnter;
                    break;
                case HoverState.HoverEnter:
                    HandleHoverEnter();
                    break;
                case HoverState.Hovered:
                    HandleHover();
                    break;
                case HoverState.HoverExit:
                    HandleHoverExit();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();

            }
        }

        private void HandleHoverEnter()
        {
            // Call Events
            var e = new OnHoverEnterEvent();
            _onHoverEnter.Invoke(e);
            OnHoverEnter?.Invoke(e);

            // Change State
            _hoverState = HoverState.Hovered;
            _hoverEnterTime = Time.time;
        }

        private void HandleHover()
        {
            if (!CheckHover())
                _hoverState = HoverState.HoverExit;

            OnHover?.Invoke(new OnHoverEvent(_hoverEnterTime));
        }

        private void HandleHoverExit()
        {
            // Call Events
            _onHoverExit.Invoke(new OnHoverExitEvent(_hoverEnterTime));
            OnHoverExit?.Invoke(new OnHoverExitEvent(_hoverEnterTime));

            // Change State
            _hoverState = HoverState.None;
        }

        private bool CheckHover()
        {
            RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));

            return hit.collider != null && hit.transform == transform;
        }

        public enum HoverState
        {
            None,
            HoverEnter,
            Hovered,
            HoverExit
        }
    }

    #region Events

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

    #endregion
}
