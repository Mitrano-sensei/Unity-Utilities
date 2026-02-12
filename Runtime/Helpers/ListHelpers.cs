using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Utilities
{
    public static class ListHelpers
    {
        public static T GetRandom<T>(this List<T> list) => list[Random.Range(0, list.Count)];
        public static List<T> Shuffle<T>(this List<T> list) => list.OrderBy(x => Random.Range(0, int.MaxValue)).ToList();
    }
}