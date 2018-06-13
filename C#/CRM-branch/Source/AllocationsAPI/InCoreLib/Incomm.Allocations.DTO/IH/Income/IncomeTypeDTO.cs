namespace Incomm.Allocations.DTO.IH.Income
{
    /// <summary>
    /// </summary>
    public class IncomeTypeDTO
    {
        /// <summary>
        /// </summary>
        public int IncomeTypeId { get; set; }

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
