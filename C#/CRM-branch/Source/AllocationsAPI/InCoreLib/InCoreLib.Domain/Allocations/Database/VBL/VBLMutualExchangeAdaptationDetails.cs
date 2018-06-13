using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database.VBL
{
   [TrackChanges]
    public class VBLMutualExchangeAdaptationDetails: BaseObject
    {
        [Key, Column(Order = 0)]
        public int ApplicationId { get; set; }
        [Key, Column(Order = 1)]
        public int AdaptationId { get; set; }
        public virtual Adaptation Adaptation { get; set; }
        public VBLMutualExchagePropertyDetail VBLMutualExchagePropertyDetail { get; set; }
    }
}
