using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Incomm.Allocations.BLL.Interfaces.VBL;
using InCoreLib.DAL;
using InCoreLib.Domain.Allocations.Database.VBL;
using System.Web.Http.OData.Query;
using AutoMapper;
using System;
using InCoreLib.Helpers;

namespace Incomm.Allocations.BLL.VBL
{
    public class VBLNoteBLL : IVBLNoteBLL
    {
        private IUnitOfWork _unitOfWork;
     
        public VBLNoteBLL() : this(new UnitOfWork())
        {
        }

        public VBLNoteBLL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
          
        }
        public List<VBLNote> GetVBLNotes(ODataQueryOptions<VBLNote> options)
        {
            var contacts =
               options.ApplyTo(_unitOfWork.VBLNotes().Select2(x => true, includeProperties: i =>
                       new
                       {
                           i.VBLContact
                       })
               .AsNoTracking()
               .AsQueryable());
            return Mapper.Map<List<VBLNote>>(contacts);
        }

        public VBLNoteDTO CreateNote(VBLNote note)
        {
            var result = new VBLNoteDTO();
            var persistedContact = _unitOfWork.VBLContacts().Select().FirstOrDefault(x => x.ContactId == note.ContactId);
            if(persistedContact == null)
            {
                result.ErrorMessage = "The Contact is already deleted. Please retry.";
            }
            else
            {
                _unitOfWork.VBLNotes().Insert(note);
            }
            _unitOfWork.Commit(note.UserId, note.UserIPAddress);
            return result;
        }

        public VBLNoteDTO UpdateNote(VBLNote note)
        {
            var result = new VBLNoteDTO();
            var persistedNote = _unitOfWork.VBLNotes().Select().FirstOrDefault(x => x.NoteId == note.NoteId);
            var persistedContact = _unitOfWork.VBLContacts().Select().FirstOrDefault(x => x.ContactId == note.ContactId);
            if (persistedContact == null)
            {
                result.ErrorMessage = string.Format("The Contact is already deleted. Please retry.");
            }
            else if (note.RowVersion.ConvertByteArrayToString() !=persistedNote.RowVersion.ConvertByteArrayToString())
            {
                result.ErrorMessage =
                    $"The note is already updated by {persistedNote.ModifiedBy} at {persistedNote.ModifiedDate.ToString()}. Please retry.";
            }
            else
            {
                _unitOfWork.VBLNotes().Update(note);
            }
            _unitOfWork.Commit(note.UserId, note.UserIPAddress);
            return result;
        }
    }
}
