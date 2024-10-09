using UnityEngine;
using UnityEngine.Events;
using System;

namespace Utilities
{
    public class Hoverable3DFPS : MonoBehaviour
    {
        #region Fields
        [Header("Events")]
        [SerializeField] private OnHoverEnter _onHoverEnter = new();
        [SerializeField] private OnHoverExit _onHoverExit = new();

        private HoverState _hoverState = HoverState.None;

        private float _hoverEnterTime;

        public UnityAction<OnHoverEnterEvent> OnHoverEnter;
        public UnityAction<OnHoverEvent> OnHover;
        public UnityAction<OnHoverExitEvent> OnHoverExit;

        public bool IsHovered => _hoverState == HoverState.Hovered;
        #endregion

        #region MonoBehaviour
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
        #endregion

        #region Methods

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

        protected virtual bool CheckHover()
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0f));
            RaycastHit hit;

            return Physics.Raycast(ray, out hit) && hit.collider != null && hit.transform == transform;
        }

        #endregion


    }
}
