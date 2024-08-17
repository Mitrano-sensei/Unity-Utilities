using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{
    public class CoroutineHelpers
    {
        public static IEnumerator AfterDelay(float delay, System.Action action)
        {
           yield return new WaitForSeconds(delay);

           action();
        }

        public static IEnumerator AfterDelay(float delay, IEnumerator action)
        {
            yield return new WaitForSeconds(delay);

            yield return action;
        }
    }
}