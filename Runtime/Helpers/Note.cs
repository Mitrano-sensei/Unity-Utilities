using UnityEngine;

namespace Utilities
{
    /**
     * Meant to add a notes field to inspector
     */
    public class Note : MonoBehaviour
    {
        [TextArea(3, 20)] public string note;
    }
}