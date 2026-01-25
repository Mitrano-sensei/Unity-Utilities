using System.Collections.Generic;
using System.Linq;

namespace Utilities
{
    public delegate T SelectionStrategy<T>(IEnumerable<T> items);
    
    public static class Registry<T> where T : class
    {
        private static readonly HashSet<T> items = new();

        public static bool TryAdd(T item)
        {
            return item != null && items.Add(item);
        }
        
        public static bool TryRemove(T item)
        {
            return item != null && items.Remove(item);
        }

        public static T GetFirst()
        {
            return items.FirstOrDefault();
        }

        public static T Get(SelectionStrategy<T> strategy) => strategy(items);

        public static IEnumerable<T> All => items;

    }
}