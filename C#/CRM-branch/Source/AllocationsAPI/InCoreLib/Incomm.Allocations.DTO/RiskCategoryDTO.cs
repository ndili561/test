namespace Incomm.Allocations.DTO
{
    /// <summary>
    /// </summary>
    public class RiskCategoryDTO
    {
        /// <summary>
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// </summary>
        public int? SortOrder { get; set; }
    }
}
