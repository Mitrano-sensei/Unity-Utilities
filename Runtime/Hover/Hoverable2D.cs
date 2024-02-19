using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Utilities
{
    [RequireComponent(typeof(Collider2D))]
    public class Hoverable2D : MonoBehaviour
    {

        [SerializeField] private OnHoverEnter _onHoverEnter = new();
        [SerializeField] private OnHoverExit _onHoverExit = new();

        private HoverState _hoverState = HoverState.None;

        private float _hoverEnterTime;

        public OnHoverEnter OnHoverEnter { get => _onHoverEnter; set => _onHoverEnter = value; }
        public OnHoverExit OnHoverExit { get => _onHoverExit; set => _onHoverExit = value; }

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
                    _onHoverEnter.Invoke(new OnHoverEnterEvent());
                    _hoverState = HoverState.Hovered;
                    _hoverEnterTime = Time.time;
                    break;
                case HoverState.Hovered:
                    if (!CheckHover())
                        _hoverState = HoverState.HoverExit;
                    break;
                case HoverState.HoverExit:
                    _onHoverExit.Invoke(new OnHoverExitEvent(_hoverEnterTime));
                    _hoverState = HoverState.None;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();

            }
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

    #endregion
}
