using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using AutoMapper;
using Incomm.Allocations.BLL.Interfaces.VBL;
using Incomm.Allocations.DTO;
using InCoreLib.DAL;
using InCoreLib.Domain.Allocations.Database.VBL;
using InCoreLib.Helpers;

namespace Incomm.Allocations.BLL.VBL
{
    public class IncommunitiesRelationshipBLL : IIncommunitiesRelationshipBLL
    {
        private readonly IUnitOfWork _unitOfWork;

        public IncommunitiesRelationshipBLL() : this(new UnitOfWork())
        { }

        public IncommunitiesRelationshipBLL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public VBLIncommunitiesRelationshipDTO Get(int vblIncommunitiesRelationshipId)
        {
            var relationship =
                _unitOfWork.VBLIncommunitiesRelationships()
                    .Select(r => r.VBLIncommunitiesRelationshipId == vblIncommunitiesRelationshipId)
                    .SingleOrDefault();

            return Mapper.Map<VBLIncommunitiesRelationshipDTO>(relationship);
        }

        public VBLIncommunitiesRelationshipDTO GetByContactId(int contactId)
        {
            var relationship =
                _unitOfWork.VBLIncommunitiesRelationships()
                    .Select(r => r.ContactId == contactId)
                    .SingleOrDefault();

            return Mapper.Map<VBLIncommunitiesRelationshipDTO>(relationship);
        }

        public void Delete(VBLIncommunitiesRelationshipDTO relationship)
        {
            var relationshipDb = _unitOfWork.VBLIncommunitiesRelationships()
                    .Select(r => r.VBLIncommunitiesRelationshipId == relationship.VBLIncommunitiesRelationshipId)
                    .SingleOrDefault();

            Validate(relationship, relationshipDb);

            _unitOfWork.VBLIncommunitiesRelationships().Delete(relationshipDb);
            _unitOfWork.Commit(relationship.UserId, relationship.UserIPAddress);
        }

        public void Save(VBLIncommunitiesRelationshipDTO relationship)
        {
            if (relationship.VBLIncommunitiesRelationshipId == 0)
            {
                Insert(relationship);
            }
            else
            {
                Update(relationship);
            }
        }

        private void Update(VBLIncommunitiesRelationshipDTO relationship)
        {
            var relationshipDb = _unitOfWork.VBLIncommunitiesRelationships()
                    .Select(r => r.VBLIncommunitiesRelationshipId == relationship.VBLIncommunitiesRelationshipId)
                    .SingleOrDefault();

            Validate(relationship, relationshipDb);

            relationshipDb.HasIncommunitiesRelationship = relationship.HasIncommunitiesRelationship;
            relationshipDb.IncommunitiesRelationshipDescription = relationship.IncommunitiesRelationshipDescription;
            relationshipDb.ModifiedBy = relationship.UserId;
            relationshipDb.ModifiedDate = DateTime.Now;

            _unitOfWork.VBLIncommunitiesRelationships().Update(relationshipDb);
            _unitOfWork.Commit(relationship.UserId, relationship.UserIPAddress);
        }

        private void Insert(VBLIncommunitiesRelationshipDTO relationship)
        {
            var relationshipDb = new VBLIncommunitiesRelationship
            {
                ContactId = relationship.ContactId,
                HasIncommunitiesRelationship = relationship.HasIncommunitiesRelationship,
                IncommunitiesRelationshipDescription = relationship.IncommunitiesRelationshipDescription,
                CreatedBy = relationship.UserId,
                CreatedDate = DateTime.Now
            };

            _unitOfWork.VBLIncommunitiesRelationships().Insert(relationshipDb);
            _unitOfWork.Commit(relationship.UserId, relationship.UserIPAddress);
        }

        private void Validate(VBLIncommunitiesRelationshipDTO relationship, VBLIncommunitiesRelationship relationshipDb)
        {
            if (relationshipDb == null)
            {
                throw new ArgumentNullException($"Relationship with Id {relationship.VBLIncommunitiesRelationshipId} for contactId {relationship.ContactId} does not exist.");
            }

            if (relationship.RowVersion.ConvertByteArrayToString() !=
                relationshipDb.RowVersion.ConvertByteArrayToString())
            {
                throw new ValidationException("The relationship was modified. Concurrency error.");
            }
        }
    }
}
