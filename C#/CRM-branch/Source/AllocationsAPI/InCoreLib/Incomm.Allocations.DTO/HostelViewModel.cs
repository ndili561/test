using System.Collections.Generic;
using InCoreLib.Helpers;

namespace Incomm.Allocations.BLL.DTOs
{
    public class HostelViewModel : BaseFilterModel
    {
        public HostelViewModel()
        {
            HostelSearchResult = new List<HostelDTO>();
        }

        public HostelDTO HostelDto
        {
            get
            {
                return new HostelDTO();
            }
        }
        public HostelDTO HostelSearchModel { get; set; }
        public List<HostelDTO> HostelSearchResult { get; set; }
        public bool Active { get; set; }
    }
}
