namespace Incomm.Allocations.BLL.DTOs
{
    public class ServiceTypeDTO : BaseObjectDto
    {
        public int ServiceTypeId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public int? SortOrder { get; set; }
    

    }
}
