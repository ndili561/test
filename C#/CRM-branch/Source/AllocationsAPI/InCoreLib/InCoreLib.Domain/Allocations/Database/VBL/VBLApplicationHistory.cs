using System.ComponentModel.DataAnnotations;
using InCoreLib.Domain.Allocations.Enumerations;

namespace InCoreLib.Domain.Allocations.Database.VBL
{
    public class VBLApplicationHistory : BaseObject
    {
        [Key]
        public int Id { get; set; }
        public ApplicationActivity ApplicationActivity { get; set; }
        public ApplicationChangeType ApplicationChangeType { get; set; }
        public string ApplicationChangeDescription { get; set; }
        public int ApplicationId { get; set; }
        public VBLApplication VBLApplication { get; set; }
        public string PropertyCode { get; set; }
        public bool CanReconsider { get; set; }

    }
}
