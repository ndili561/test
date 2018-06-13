using System.Collections.Generic;

namespace Incomm.Allocations.DTO
{
    /// <summary>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EntityPager<T>
    {
        /// <summary>
        /// </summary>
        public IEnumerable<T> Results { get; set; }

        /// <summary>
        /// </summary>
        public int CurrentPageNumber { get; set; }

        /// <summary>
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// </summary>
        public int TotalPages { get; set; }
    }
}
