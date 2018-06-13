using System.Collections.Generic;
using Incomm.Allocations.BLL.DTOs;

namespace Incomm.Allocations.BLL.Interfaces
{
    public interface ISupportTypeBLL
    {
        List<SupportTypeDTO> GetSupportTypes();
        SupportTypeDTO GetSupportType(int supportTypeId);
        SupportTypeDTO Create(SupportTypeDTO supportTypeDto);
        SupportTypeDTO Update(SupportTypeDTO supportTypeDto);
    }
}