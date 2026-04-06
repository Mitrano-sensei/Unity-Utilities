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
        
        /// <summary>
        /// From: https://discussions.unity.com/t/find-anchoredposition-of-a-recttransform-relative-to-another-recttransform/583345/4
        /// Converts the anchoredPosition of the first RectTransform to an anchorpoint relative to the second RectTransform,
        /// taking into consideration offset, anchors and pivot, and returns the new anchoredPosition
        ///
        /// For example:
        /// If one RectTransform (A) is anchored leftside of the canvas with x = 0, and the other RectTransform (B) is anchored rightside of the canvas with x = 0,
        /// and the canvas is 100 wide; GetRelativeAnchorPoint(A, B) will be Vector2(-100, 0), corresponding to A's coordinate in B's system.
        /// </summary>
        public static Vector2 GetRelativeAnchorPoint(RectTransform from, RectTransform to)
        {
            Vector2 fromPivotDerivedOffset = new Vector2(from.rect.width * from.pivot.x + from.rect.xMin, from.rect.height * from.pivot.y + from.rect.yMin);
            Vector2 screenP = RectTransformUtility.WorldToScreenPoint(null, from.position);
            screenP += fromPivotDerivedOffset;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(to, screenP, null, out var localPoint);
            Vector2 pivotDerivedOffset = new Vector2(to.rect.width * to.pivot.x + to.rect.xMin, to.rect.height * to.pivot.y + to.rect.yMin);
            return to.anchoredPosition + localPoint - pivotDerivedOffset;
        }
    }
}