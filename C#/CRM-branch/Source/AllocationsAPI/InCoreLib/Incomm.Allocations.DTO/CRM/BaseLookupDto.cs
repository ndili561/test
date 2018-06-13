namespace Incomm.Allocations.DTO.CRM
{
    public abstract class BaseLookupDto: BaseDto
    {
        public string Name { get; set; }
        public int SortOrder { get; set; }
        
        public bool IsActive { get; set; }
    }
}
