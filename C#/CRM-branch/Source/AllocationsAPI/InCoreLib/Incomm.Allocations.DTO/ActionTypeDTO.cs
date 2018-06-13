namespace Incomm.Allocations.DTO
{
    /// <summary>
    /// </summary>
    public class ActionTypeDTO
    {
        /// <summary>
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// </summary>
        public int ActionCategoryId { get; set; }

        /// <summary>
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// </summary>
        public int? SortOrder { get; set; }
    }

}
