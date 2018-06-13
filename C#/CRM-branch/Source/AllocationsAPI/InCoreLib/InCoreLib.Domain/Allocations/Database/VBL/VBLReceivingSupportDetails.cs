using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InCoreLib.Domain.Allocations.Database.VBL
{
   [TrackChanges]
    public class VBLReceivingSupportDetails : BaseObject
    {
        [Key]
        public int ReceivingSupportDetailId { get; set; }
        public string Name { get; set; }
        public int SupportTypeId { get; set; }
        public virtual VBLSupportType SupportType { get; set; }
        public int SupportProviderId { get; set; }
        public virtual VBLSupportProvider SupportProvider { get; set; }
        public int ContactId { get; set; }
        public VBLContact Contact { get; set; }
        public virtual ICollection<VBLSupportContactByDetails> ContactByDetails { get; set; }
        public bool ThirdPartyAuth { get; set; }
    }
}
