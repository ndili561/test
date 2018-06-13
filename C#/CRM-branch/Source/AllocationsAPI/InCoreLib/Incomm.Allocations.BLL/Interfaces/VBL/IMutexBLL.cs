using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Incomm.Allocations.DTO;

namespace Incomm.Allocations.BLL.Interfaces.VBL
{
    public interface IMutexBLL
    {
        MutualExchangeDTO AcceptMutex(MutualExchangeDTO mutexNotification);
        MutualExchangeDTO RefuseMutex(MutualExchangeDTO mutexNotification);
    }
}
