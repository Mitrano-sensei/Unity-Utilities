using UnityEngine;

namespace Utilities
{
    public static class RigidbodyHelpers
    {
        #region Extension Methods

        public static void ApplyVelocity(this Rigidbody rigidbody, Vector3 desiredVelocity)
        {
            rigidbody.AddForce(desiredVelocity - rigidbody.linearVelocity, ForceMode.VelocityChange);
        }

        public static void RemoveVerticalVelocity(this Rigidbody rigidbody)
        {
            rigidbody.ApplyVerticalVelocity(0f);
        }

        public static void ApplyVerticalVelocity(this Rigidbody rigidbody, float newVerticalVelocity)
        {
            rigidbody.ApplyVelocity(rigidbody.linearVelocity.WithY(newVerticalVelocity));
        }

        #endregion
    }
}
