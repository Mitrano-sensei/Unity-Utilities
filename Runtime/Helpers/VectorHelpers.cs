using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{
    public static class VectorHelpers
    {
        #region Vector3

        #region With
        public static Vector3 With(this Vector3 vector, float? x = null, float? y = null, float? z = null)
        {
            return new Vector3(x ?? vector.x, y ?? vector.y, z ?? vector.z);
        }

        public static Vector3 WithX(this Vector3 vector, float x)
        {
            return new Vector3(x, vector.y, vector.z);
        }

        public static Vector3 WithY(this Vector3 vector, float y)
        {
            return new Vector3(vector.x, y, vector.z);
        }

        public static Vector3 WithZ(this Vector3 vector, float z)
        {
            return new Vector3(vector.x, vector.y, z);
        }
        #endregion

        #region Add

        public static Vector3 Add(this Vector3 vector, float? x = null, float? y = null, float? z = null)
        {
            return new Vector3(vector.x + (x ?? 0), vector.y + (y ?? 0), vector.z + (z ?? 0));
        }

        public static Vector3 AddX(this Vector3 vector, float x)
        {
            return new Vector3(vector.x + x, vector.y, vector.z);
        }

        public static Vector3 AddY(this Vector3 vector, float y)
        {
            return new Vector3(vector.x, vector.y + y, vector.z);
        }

        public static Vector3 AddZ(this Vector3 vector, float z)
        {
            return new Vector3(vector.x, vector.y, vector.z + z);
        }
        #endregion

        #endregion

        #region Vector3Int

        #region With

        public static Vector3Int With(this Vector3Int vector, int? x = null, int? y = null, int? z = null)
        {
            return new Vector3Int(x ?? vector.x, y ?? vector.y, z ?? vector.z);
        }
        
        public static Vector3Int WithX(this Vector3Int vector, int x)
        {
            return new Vector3Int(x, vector.y, vector.z);
        }
        
        public static Vector3Int WithY(this Vector3Int vector, int y)
        {
            return new Vector3Int(vector.x, y, vector.z);
        }
        
        public static Vector3Int WithZ(this Vector3Int vector, int z)
        {
            return new Vector3Int(vector.x, vector.y, z);
        }

        #endregion
        
        #region Add
        
        public static Vector3Int Add(this Vector3Int vector, int? x = null, int? y = null, int? z = null)
        {
            return new Vector3Int(vector.x + (x ?? 0), vector.y + (y ?? 0), vector.z + (z ?? 0));
        }
        
        public static Vector3Int AddX(this Vector3Int vector, int x)
        {
            return new Vector3Int(vector.x + x, vector.y, vector.z);
        }
        
        public static Vector3Int AddY(this Vector3Int vector, int y)
        {
            return new Vector3Int(vector.x, vector.y + y, vector.z);
        }
        
        public static Vector3Int AddZ(this Vector3Int vector, int z)
        {
            return new Vector3Int(vector.x, vector.y, vector.z + z);
        }
        
        #endregion

        #endregion

        #region Vector2

        #region With
        public static Vector2 With(this Vector2 vector, float? x = null, float? y = null)
        {
            return new Vector2(x ?? vector.x, y ?? vector.y);
        }

        public static Vector2 WithX(this Vector2 vector, float x)
        {
            return new Vector2(x, vector.y);
        }

        public static Vector2 WithY(this Vector2 vector, float y)
        {
            return new Vector2(vector.x, y);
        }

        #endregion

        #region Add

        public static Vector2 Add(this Vector2 vector, float? x = null, float? y = null)
        {
            return new Vector2(vector.x + (x ?? 0), vector.y + (y ?? 0));
        }

        public static Vector2 AddX(this Vector2 vector, float x)
        {
            return new Vector2(vector.x + x, vector.y);
        }

        public static Vector2 AddY(this Vector2 vector, float y)
        {
            return new Vector2(vector.x, vector.y + y);
        }

        #endregion

        #endregion
    }
}
