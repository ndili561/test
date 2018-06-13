using System;
using System.Collections.Generic;
using System.Linq;
using Incomm.Allocations.BLL.Interfaces.VBL;
using InCoreLib.DAL;
using InCoreLib.Domain.Allocations.Database.VBL;
using InCoreLib.Domain.Allocations.Enumerations;

namespace Incomm.Allocations.BLL.VBL
{
    public class RequestedPropertyPrefferedNeighbourhoodBLL : IRequestedPropertyPrefferedNeighbourhoodBLL
    {

        private readonly IUnitOfWork _unitOfWork;
        private IApplicationHistoryBLL _applicationHistoryBLL;
        private IApplicationBLL _applicationBLL;
        public RequestedPropertyPrefferedNeighbourhoodBLL() : this(new UnitOfWork(), new ApplicationBLL(), new ApplicationHistoryBLL())
        {
        }

        public RequestedPropertyPrefferedNeighbourhoodBLL(IUnitOfWork unitOfWork, IApplicationBLL applicationBLL, IApplicationHistoryBLL applicationHistoryBLL)
        {
            _unitOfWork = unitOfWork;
            _applicationHistoryBLL = applicationHistoryBLL;
            _applicationBLL = applicationBLL;
        }

        public VBLRequestedPropertyPrefferedNeighbourhood Create(VBLRequestedPropertyPrefferedNeighbourhood entityToSave)
        {
            try
            {
                var changeDescription = string.Empty;
                var persistedApplication = _applicationBLL.GetApplicationForPropertyPreferencePages(entityToSave.ApplicationId);
                if (persistedApplication.VBLRequestedPropertymatchDetail?.RequestedPropertyPrefferedNeighbourhoods != null)
                {
                    //persistedApplication.ApplicationStatusID = 1;
                    persistedApplication.VBLRequestedPropertymatchDetail.RequestedPropertyPrefferedNeighbourhoods.ForEach(x => x.IsCurrent = false);
                    _unitOfWork.RequestedPropertyPrefferedNeighbourhood().UpdateRange(persistedApplication.VBLRequestedPropertymatchDetail.RequestedPropertyPrefferedNeighbourhoods);
                    _unitOfWork.Commit(entityToSave.CreatedBy, entityToSave.UserIPAddress);
                }
           
                var entity = new VBLRequestedPropertyPrefferedNeighbourhood
                {
                    ApplicationId = entityToSave.ApplicationId,
                    IsCurrent = true,
                    CreatedDate = entityToSave.CreatedDate,
                    ModifiedBy = entityToSave.UserId,
                    UserId = entityToSave.UserId,
                    UserIPAddress = entityToSave.UserIPAddress,
                    RequestedPropertyPrefferedNeighbourhoodDetails = new List<VBLRequestedPropertyPrefferedNeighbourhoodDetail>()
                };
                _unitOfWork.RequestedPropertyPrefferedNeighbourhood().Insert(entity);
                _unitOfWork.Commit(entityToSave.CreatedBy, entityToSave.UserIPAddress);
                foreach (var vblRequestedPropertyPrefferedNeighbourhoodDetail in entityToSave.RequestedPropertyPrefferedNeighbourhoodDetails)
                {
                    entity.RequestedPropertyPrefferedNeighbourhoodDetails.Add(new VBLRequestedPropertyPrefferedNeighbourhoodDetail
                    {
                        NeighbourhoodId = vblRequestedPropertyPrefferedNeighbourhoodDetail.NeighbourhoodId,
                        CreatedDate = entityToSave.CreatedDate,
                        UserId = entityToSave.UserId,
                        ModifiedBy = entityToSave.UserId,
                        UserIPAddress = entityToSave.UserIPAddress
                    });
                }
             
                //var vblRequestedPropertyPrefferedNeighbourhood = persistedApplication.VBLRequestedPropertymatchDetail.RequestedPropertyPrefferedNeighbourhoods.OrderByDescending(x=>x.RequestedPropertyPrefferedNeighbourhoodId).FirstOrDefault();
                //if (vblRequestedPropertyPrefferedNeighbourhood != null)
                //{
                //    var originalValue = string.Join(", ", vblRequestedPropertyPrefferedNeighbourhood.RequestedPropertyPrefferedNeighbourhoodDetails.Select(x => x.PropertyNeighbourhood.Name));
                //    if (!string.IsNullOrWhiteSpace(originalValue))
                //    {
                //        var selectedPropertyNeighbourhoods =
                //            _unitOfWork.VBLPropertyNeighbourhoods()
                //                .Select()
                //                .Where(x => x.NeighbourhoodId == entityToSave.RequestedPropertyPrefferedNeighbourhoodId);
                //        var currentValue = string.Join(", ", selectedPropertyNeighbourhoods.Select(x => x.Name));
                //        changeDescription = $"Move Reason changed from <span class=\"oldvalue\"> {(originalValue)} </span>  to <span class=\"newvalue\"> {currentValue} </span>";
                //        _applicationHistoryBLL.Create(entityToSave.ApplicationId, entityToSave.UserId, entityToSave.UserIPAddress, ApplicationActivity.Ammendment, ApplicationChangeType.PropertyDetails, changeDescription);
                //    }
                 
                //}
                _unitOfWork.RequestedPropertyPrefferedNeighbourhood().Update(entity);
                _unitOfWork.Commit(entityToSave.CreatedBy, entityToSave.UserIPAddress);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return entityToSave;
        }
    }
}