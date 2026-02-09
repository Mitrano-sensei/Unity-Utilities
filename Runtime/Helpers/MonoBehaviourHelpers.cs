using System;
using UnityEngine;

namespace Utilities
{
    public static class MonoBehaviourHelpers
    {
        #region Extension Methods
        
        public static T GetComponentIfNull<T>(this MonoBehaviour monoBehaviour, T component)
        {
            if (component != null)
                return component;

            return monoBehaviour.GetComponentOrException<T>();
        }
        
        public static T GetComponentInParentIfNull<T>(this MonoBehaviour monoBehaviour, T component)
        {
            if (component != null)
                return component;
            
            return monoBehaviour.GetComponentInParentOrException<T>();
        }
        
        public static T GetComponentInChildrenIfNull<T>(this MonoBehaviour monoBehaviour, T component)
        {
            if (component != null)
                return component;
            
            return monoBehaviour.GetComponentInChildrenOrException<T>();
        }

        public static T GetComponentOrException<T>(this MonoBehaviour monoBehaviour)
        {
            var component = monoBehaviour.GetComponent<T>();
            if (component == null)
                throw new Exception("Component not found on " + monoBehaviour.name);
            return component;
        }
        
        public static T GetComponentInParentOrException<T>(this MonoBehaviour monoBehaviour)
        {
            var component = monoBehaviour.GetComponentInParent<T>();
            if (component == null)
                throw new Exception("Component not found on " + monoBehaviour.name + " parents");
            return component;
        }
        
        public static T GetComponentInChildrenOrException<T>(this MonoBehaviour monoBehaviour)
        {
            var component = monoBehaviour.GetComponentInChildren<T>();
            if (component == null)
                throw new Exception("Component not found on " + monoBehaviour.name + " children");
            return component;
        }
        
        public static T GetOrAddComponent<T>(this MonoBehaviour monoBehaviour) where T : Component
        {
            var component = monoBehaviour.GetComponent<T>();
            if (component == null)
                component = monoBehaviour.gameObject.AddComponent<T>();
            return component;
        }
        
        #endregion
    }
}