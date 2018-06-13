namespace Incomm.Allocations.DTO.IH.Expenditure
{
    /// <summary>
    /// </summary>
    public class ExpenditureTypeDTO
    {
        /// <summary>
        /// </summary>
        public int ExpenditureTypeId { get; set; }

        /// <summary>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// </summary>
        public int SortOrder { get; set; }

        /// <summary>
        /// </summary>
        public bool AllowMultiple { get; set; }
    }
}
