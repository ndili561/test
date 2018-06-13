using System.ComponentModel.DataAnnotations;
using InCoreLib.Domain.Allocations.Enumerations;

namespace InCoreLib.Domain.Allocations.Database.VBL
{
   [TrackChanges]
    public class VBLDocument: BaseObject
    {
        [Key]
        public int DocumentId { get; set; }
        public int ApplicationId { get; set; }
        public virtual VBLApplication Application { get; set; }

        [StringLength(250)]
        public string DocumentName { get; set; }
        public DocumentType DocumentType { get; set; }

        [StringLength(500)]
        public string DocumentPath { get; set; }


    }
}
