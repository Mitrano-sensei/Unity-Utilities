using System;
using UnityEngine;
using UnityEngine.Events;

namespace Utilities
{
    [RequireComponent(typeof(Collider2D))]
    public class Draggable2D : MonoBehaviour
    {
        [Header("Misc")] 
        [SerializeField] private float dragDelay = 0.1f;
        [SerializeField] private bool enableDragMove = true;

        [Header("Events")] 
        [SerializeField] private OnDragStart onDragStart = new();
        [SerializeField] private OnDragEnd onDragEnd = new();
        [SerializeField] private UnityEvent onClick = new();

        private Camera _camera;

        private Vector3 _offset;
        private Vector3 _initialPosition;

        private float _dragEnterTime;

        public UnityAction<OnDragStartEvent> OnDragStart;
        public UnityAction<OnDragEndEvent> OnDragEnd;
        public UnityAction OnClick;

        public bool IsDragging { get; private set; }

        public bool EnableDragMove
        {
            get => enableDragMove;
            set => enableDragMove = value;
        }

        public void Start()
        {
            IsDragging = false;
            _camera = Camera.main;
        }

        public void Update()
        {
            var time = Time.time - _dragEnterTime;

            if (!enableDragMove || !IsDragging || !(time > dragDelay)) return; // Here we don't want to move the object

            Vector3 mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePos.x + _offset.x, mousePos.y + _offset.y, transform.position.z);
        }

        public void OnMouseDown()
        {
            _offset = transform.position - _camera.ScreenToWorldPoint(Input.mousePosition);

            if (!IsDragging)
            {
                _initialPosition = transform.position;
                _dragEnterTime = Time.time;

                var e = new OnDragStartEvent(_initialPosition, _dragEnterTime);
                OnDragStart?.Invoke(e);
                onDragStart.Invoke(e);
            }

            IsDragging = true;
        }

        public void OnMouseUp()
        {
            if (IsDragging)
            {
                var e = new OnDragEndEvent(_initialPosition, _dragEnterTime, Time.time);

                onDragEnd.Invoke(e);
                OnDragEnd?.Invoke(e);

                var time = Time.time - _dragEnterTime;
                if (time < dragDelay)
                {
                    OnClick?.Invoke();
                    onClick.Invoke();
                }
            }

            IsDragging = false;
        }
    }

    #region Events*

    public class OnDragEndEvent
    {
        public Vector3 InitialPosition { get; }
        public float DragEnterTime { get; }
        public float DragEndTime { get; }

        public OnDragEndEvent(Vector3 initialPosition, float dragEnterTime, float dragEndTime)
        {
            InitialPosition = initialPosition;
            DragEnterTime = dragEnterTime;
            DragEndTime = dragEndTime;
        }
    }

    public class OnDragStartEvent
    {
        public Vector3 InitialPosition { get; }
        public float DragEnterTime { get; }

        public OnDragStartEvent(Vector3 initialPosition, float dragEnterTime)
        {
            InitialPosition = initialPosition;
            DragEnterTime = dragEnterTime;
        }
    }

    [Serializable]
    public class OnDragEnd : UnityEvent<OnDragEndEvent>
    {
    }

    [Serializable]
    public class OnDragStart : UnityEvent<OnDragStartEvent>
    {
    }

    #endregion
}