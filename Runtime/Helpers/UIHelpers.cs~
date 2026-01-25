using UnityEngine;

namespace Utilities
{
    public static class UIHelpers
    {
        public static Vector3 WorldToUIPosition(RectTransform canvasRect, Vector3 worldPosition) =>
            canvasRect.InverseTransformPoint(worldPosition);

        public static Vector3 UIToWorldPosition(RectTransform canvasRect, Vector3 uiPosition) =>
            canvasRect.TransformPoint(uiPosition);

        public static void MoveOnCanvas(this RectTransform rectTransform, RectTransform canvas, Vector2 uiPosition) =>
            rectTransform.position = UIToWorldPosition(canvas, uiPosition);
    }
}