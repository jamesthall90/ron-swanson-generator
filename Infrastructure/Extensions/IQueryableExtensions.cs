using System;
using System.Linq;

namespace Infrastructure.Extensions
{
    public static class IQueryableExtensions
    {
        // Pseudo-randomizes the order of the elements in the list
        public static void Shuffle<T>(this IQueryable<T> query)
        {
            query.OrderBy(a => Guid.NewGuid());
        }
    }
}