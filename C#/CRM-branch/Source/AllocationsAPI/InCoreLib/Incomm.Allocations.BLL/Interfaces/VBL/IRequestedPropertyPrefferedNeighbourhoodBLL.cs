using InCoreLib.Domain.Allocations.Database.VBL;

namespace Incomm.Allocations.BLL.Interfaces.VBL
{
    public interface IRequestedPropertyPrefferedNeighbourhoodBLL
    {
        VBLRequestedPropertyPrefferedNeighbourhood Create(VBLRequestedPropertyPrefferedNeighbourhood entityToSave);
    }
}