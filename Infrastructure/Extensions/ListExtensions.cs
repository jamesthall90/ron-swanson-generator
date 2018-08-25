using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Extensions
{
    public static class ListExtensions
    {
        // Checks to see if the list is null or empty
        public static bool IsNullOrEmpty<T>(this IList<T> list) 
        {
            return ( list == null || list.Count < 1 );
        }

        // Pseudo-randomizes the order of the elements in the list
        public static List<T> Shuffle<T>(this IList<T> list)
        {
            return list.OrderBy(a => Guid.NewGuid()).ToList();
        }
    }
}