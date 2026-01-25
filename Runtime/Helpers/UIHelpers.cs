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
        
        public static Vector2 GetLocalCoordsFromMouseScreenPosition(RectTransform rectTransform, Vector2 mouseScreenPosition, Canvas myCanvas)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                rectTransform.parent as RectTransform,
                mouseScreenPosition,
                myCanvas.worldCamera,
                out var localPoint
            );
            return localPoint;
        }
    }
}