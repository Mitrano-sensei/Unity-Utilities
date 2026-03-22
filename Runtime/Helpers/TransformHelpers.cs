using UnityEngine;

namespace Utilities
{
    public static class TransformHelpers
    {
        public static void DestroyChildren(this Transform t)
        {
            foreach (Transform child in t)
            {
                Object.DestroyImmediate(child.gameObject);
            }
        }
    }
}