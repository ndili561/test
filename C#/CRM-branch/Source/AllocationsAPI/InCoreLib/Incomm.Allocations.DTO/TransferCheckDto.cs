namespace Incomm.Allocations.BLL.DTOs
{
    public class TransferCheckDto : BaseObjectDto
    {
        public int ContactId { get; set; }
        public bool IsAsbCheckOk { get; set; }
        public bool IsDebtCheckOk { get; set; }
        public bool IsOtherTenancyBreachesCheckOk { get; set; }
    }
}