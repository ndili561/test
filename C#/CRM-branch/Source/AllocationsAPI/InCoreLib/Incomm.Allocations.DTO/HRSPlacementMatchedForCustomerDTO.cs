using System;
using System.Collections.Generic;
using System.Linq;
using Incomm.Allocations.DTO;
using InCoreLib.Domain.Allocations.Database;
using InCoreLib.Domain.Allocations.Enumerations;

namespace Incomm.Allocations.BLL.DTOs
{
    public class HRSPlacementMatchedForCustomerDTO : BaseObjectDto
    {
        public int HRSPlacementMatchedForCustomerId { get; set; }
        public DateTime EventDate { get; set; }
        public virtual int PlacementId { get; set; }
        public virtual HRSPlacementDTO Placement { get; set; }
        public virtual int CustomerId { get; set; }
        public virtual HRSCustomerDTO Customer { get; set; }
        public virtual Status Status { get; set; }
        public virtual RejectionReason RejectionReason { get; set; }
        public byte[] ConcurrencyCheck { get; set; }
        public virtual string Notes { get; set; }

        public virtual List<HOAQuestionsAndAnswers> HOAQuestionsAndAnswerList { get; set; }

        public virtual int NumberOfTabs
        {
            get { return HOAQuestionsAndAnswerList == null || !HOAQuestionsAndAnswerList.Any() ? 0 : HOAQuestionsAndAnswerList.Count / 10 + 1; }
        }

        public bool CanAcceptOrReject
        {
            get { return Status != Status.AcceptedByProvider && Status != Status.RejectedByProvider; }
        }
    }
}