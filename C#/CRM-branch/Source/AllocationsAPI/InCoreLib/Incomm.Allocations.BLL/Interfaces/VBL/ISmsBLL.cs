using Incomm.Allocations.BLL.DTOs;
using System.Net.Http;

namespace Incomm.Allocations.BLL.Interfaces.VBL
{
    public interface ISmsBLL
    {
        bool SendSMS(VBLContactDTO contactDto, string number, string message, string userId);
        HttpResponseMessage Status();
    }
}
