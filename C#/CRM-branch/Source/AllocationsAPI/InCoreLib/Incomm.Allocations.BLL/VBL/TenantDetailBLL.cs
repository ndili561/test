using System.Collections.Generic;
using System.Linq;
using System.Web.Http.OData.Query;
using AutoMapper;
using Incomm.Allocations.BLL.Interfaces.VBL;
using InCoreLib.DAL;
using InCoreLib.Domain.Allocations.Database.VBL;

namespace Incomm.Allocations.BLL.VBL
{
    public class TenantDetailBLL : ITenantDetailBLL
    {

        private IUnitOfWork _unitOfWork;
        public TenantDetailBLL() : this(new UnitOfWork())
        {
        }

        public TenantDetailBLL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public VBLTenantDetail GeTenantDetail(int tenantDetailId)
        {
            return _unitOfWork.TenantDetails().Select().FirstOrDefault(x => x.TenantDetailId == tenantDetailId);
        }

        public List<VBLTenantDetail> GetTenantDetails(ODataQueryOptions<VBLTenantDetail> options)
        {

            var applications =
                options.ApplyTo(
                    _unitOfWork.TenantDetails()
                        .Select(includeProperties:"")
                        .AsQueryable());
            return Mapper.Map<List<VBLTenantDetail>>(applications);
        }
        public VBLTenantDetail Create(VBLTenantDetail tenantDetail)
        {
            _unitOfWork.TenantDetails().Insert(tenantDetail);
            _unitOfWork.Commit(tenantDetail.UserId, tenantDetail.UserIPAddress);
            return tenantDetail;
        }

        public VBLTenantDetail Update(VBLTenantDetail tenantDetail, VBLTenantDetail persistedTenantDetail)
        {
            persistedTenantDetail.TenantCode = tenantDetail.TenantCode;
            persistedTenantDetail.TenancyReference = tenantDetail.TenancyReference;
            persistedTenantDetail.TenancyStartDate = tenantDetail.TenancyStartDate;
            persistedTenantDetail.TenancyEndDate = tenantDetail.TenancyEndDate;
            persistedTenantDetail.IsActive = tenantDetail.IsActive;
            _unitOfWork.TenantDetails().Update(persistedTenantDetail);
            _unitOfWork.Commit(tenantDetail.UserId, tenantDetail.UserIPAddress);
            return persistedTenantDetail;
        }

        public void Delete(int contactId, string userId, string userIpAddress)
        {
            _unitOfWork.TenantDetails().Delete(contactId);
            _unitOfWork.Commit(userId,  userIpAddress);
        }
    }
}