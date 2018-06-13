using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Incomm.Allocations.BLL.Interfaces.VBL;
using Incomm.Allocations.DTO;
using InCoreLib.DAL;
using InCoreLib.Domain.Allocations.Database;
using InCoreLib.Domain.Allocations.Database.VBL;

namespace Incomm.Allocations.BLL.VBL
{
    public class MutexBLL : IMutexBLL
    {

        private IUnitOfWork _unitOfWork;
        public MutexBLL() : this(new UnitOfWork())
        {
        }

        public MutexBLL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public MutualExchangeDTO AcceptMutex(MutualExchangeDTO mutexNotification)
        {
            var ciA =
                _unitOfWork.VBLCustomerInterests()
                    .Select()
                    .First(
                        x =>
                            x.ApplicationId == mutexNotification.applicationIdA &&
                            x.PropertyCode == mutexNotification.propertyCodeB);
            ciA.CustomerInterestStatusId = mutexNotification.CIStatusA;
            ciA.ModifiedBy = mutexNotification.UserId;
            ciA.ModifiedDate = DateTime.Now;
            _unitOfWork.VBLCustomerInterests().Update(ciA);
            var ciB = new VBLCustomerInterest
            {
                PropertyCode = mutexNotification.propertyCodeA,
                VoidId = -100,
                CustomerInterestStatusId = mutexNotification.CIStatusB,
                VoidContactId = 0,
                IsPreViewingUndertaken = false,
                StatusReasonsDate = DateTime.Now,
                OutcomeNotes = "",
                CustomerDecision = true,
                Notes = "",
                TaskId = mutexNotification.TaskId ?? 0,
                ActivityId = 0,
                CreatedDate = DateTime.Now,
                CreatedBy = mutexNotification.UserId,
                ApplicationId = mutexNotification.applicationIdA,
                LandlordId = 1
            };
            _unitOfWork.VBLCustomerInterests().Insert(ciB);

            var appA = _unitOfWork.VBLApplications().Select().First(x => x.ApplicationId == mutexNotification.applicationIdA);
            var appB = _unitOfWork.VBLApplications().Select().First(x => x.ApplicationId == mutexNotification.applicationIdB);
            appA.ApplicationStatusID = 3;
            appB.ApplicationStatusID = 3;
            _unitOfWork.VBLApplications().Update(appA);
            _unitOfWork.VBLApplications().Update(appB);

            _unitOfWork.Commit();
            return mutexNotification;

            
        }

        public MutualExchangeDTO RefuseMutex(MutualExchangeDTO mutexNotification)
        {
            var ciA =
                _unitOfWork.VBLCustomerInterests()
                    .Select()
                    .First(
                        x =>
                            x.ApplicationId == mutexNotification.applicationIdA &&
                            x.PropertyCode == mutexNotification.propertyCodeB);
            ciA.CustomerInterestStatusId = mutexNotification.CIStatusA;
            ciA.ModifiedBy = mutexNotification.UserId;
            ciA.ModifiedDate = DateTime.Now;
            _unitOfWork.VBLCustomerInterests().Update(ciA);
            var ciB = new VBLCustomerInterest
            {
                PropertyCode = mutexNotification.propertyCodeA,
                VoidId = -100,
                CustomerInterestStatusId = mutexNotification.CIStatusB,
                VoidContactId = 0,
                IsPreViewingUndertaken =false,
                StatusReasonsDate = DateTime.Now,
                OutcomeNotes = "",
                CustomerDecision = true,
                Notes="",
                TaskId = mutexNotification.TaskId ?? 0,
                ActivityId = 0,
                CreatedDate = DateTime.Now,
                CreatedBy = mutexNotification.UserId,
                ApplicationId = mutexNotification.applicationIdA,
                LandlordId = 1
            };
            _unitOfWork.VBLCustomerInterests().Insert(ciB);

            _unitOfWork.Commit();
            return mutexNotification;
        }
    }
}
