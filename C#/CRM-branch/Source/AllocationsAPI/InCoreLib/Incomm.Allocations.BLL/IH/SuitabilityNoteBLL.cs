using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Incomm.Allocations.BLL.Interfaces.IH;
using Incomm.Allocations.DTO;
using Incomm.Allocations.DTO.IH.SuitabilityNote;
using InCoreLib.DAL;
using InCoreLib.Domain.Allocations.Database;
using InCoreLib.Helpers;

namespace Incomm.Allocations.BLL.IH
{
    public class SuitabilityNoteBLL : ISuitabilityNoteBLL
    {
        private readonly IUnitOfWork _unitOfWork;

        public SuitabilityNoteBLL() : this(new UnitOfWork())
        {}

        public SuitabilityNoteBLL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IList<SuitabilityNoteDTO> GetNotes(int contactId)
        {
            var notes = _unitOfWork.SuitabilityNotes().Select(n => n.ContactId == contactId).ToList();

            return Mapper.Map<IList<SuitabilityNoteDTO>>(notes);
        }

        public IList<SuitabilityNoteDTO> GetNotes(int contactId, int typeId)
        {
            var notes = _unitOfWork.SuitabilityNotes().Select(n => n.ContactId == contactId && n.SuitabilityNoteTypeId == typeId).ToList();

            return Mapper.Map<IList<SuitabilityNoteDTO>>(notes);
        }

        public EntityPager<SuitabilityNoteDTO> GetNotes(int contactId, int pageNumber, int pageSize)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return new EntityPager<SuitabilityNoteDTO>
                {
                    TotalPages = 0,
                    PageSize = 0,
                    CurrentPageNumber = 0,
                    Results = null
                };
            }

            var notes = _unitOfWork.SuitabilityNotes()
                .Select(n => n.ContactId == contactId)
                .OrderByDescending(n => n.CreatedDate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var totalNumberOfNotes = _unitOfWork.SuitabilityNotes()
                .Select(n => n.ContactId == contactId)
                .Count();

            return new EntityPager<SuitabilityNoteDTO>
            {
                Results = Mapper.Map<IList<SuitabilityNoteDTO>>(notes),
                CurrentPageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = GetTotalPages(totalNumberOfNotes, pageSize)
            };
        }

        public EntityPager<SuitabilityNoteDTO> GetNotes(int contactId, int typeId, int pageNumber, int pageSize)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return new EntityPager<SuitabilityNoteDTO>
                {
                    TotalPages = 0,
                    PageSize = 0,
                    CurrentPageNumber = 0,
                    Results = null
                };
            }

            var notes = _unitOfWork.SuitabilityNotes()
                .Select(n => n.ContactId == contactId && n.SuitabilityNoteTypeId == typeId)
                .OrderByDescending(n => n.CreatedDate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var totalNumberOfNotes = _unitOfWork.SuitabilityNotes()
                .Select(n => n.ContactId == contactId && n.SuitabilityNoteTypeId == typeId)
                .Count();

            return new EntityPager<SuitabilityNoteDTO>
            {
                Results = Mapper.Map<IList<SuitabilityNoteDTO>>(notes),
                CurrentPageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = GetTotalPages(totalNumberOfNotes, pageSize)
            };
        }

        public SuitabilityNoteDTO GetNote(int suitabilityNoteId)
        {
            var note = _unitOfWork.SuitabilityNotes().Select(n => n.SuitabilityNoteId == suitabilityNoteId).SingleOrDefault();

            return Mapper.Map<SuitabilityNoteDTO>(note);
        }

        public string SaveNote(SuitabilityNoteDTO note)
        {
            if (note == null)
            {
                return "SuitabilityNoteDTO cannot be null while saving.";
            }

            try
            {
                return note.SuitabilityNoteId == 0 ? InsertNote(note) : UpdateNote(note);
            }
            catch (Exception ex)
            {
                return GetMessage(ex);
            }
        }

        public string DeleteNote(int suitabilityNoteId, string userId, string userIp)
        {
            try
            {
                var note = _unitOfWork.SuitabilityNotes().Select(n => n.SuitabilityNoteId == suitabilityNoteId).SingleOrDefault();

                if (note == null)
                {
                    return $"Cannot delete note whit Id {suitabilityNoteId} because it does not exist.";
                }

                _unitOfWork.SuitabilityNotes().Delete(note);
                _unitOfWork.Commit(userId, userIp);

                return string.Empty;
            }
            catch (Exception ex)
            {
                return GetMessage(ex);
            }
        }

        private string UpdateNote(SuitabilityNoteDTO note)
        {
            var noteToUpdate = _unitOfWork.SuitabilityNotes().Select(n => n.SuitabilityNoteId == note.SuitabilityNoteId).SingleOrDefault();

            if (noteToUpdate == null)
            {
                return $"UpdateNote: cannot update note with Id {note.SuitabilityNoteId} because it does not exist.";
            }

            if (noteToUpdate.RowVersion.ConvertByteArrayToString() != note.RowVersion.ConvertByteArrayToString())
            {
                return $"Note with Id {note.SuitabilityNoteId} was already modified by {noteToUpdate.ModifiedBy}.";
            }

            noteToUpdate.SuitabilityNoteTypeId = note.SuitabilityNoteTypeId;
            noteToUpdate.Text = note.Text;
            noteToUpdate.ModifiedDate = DateTime.Now;
            noteToUpdate.ModifiedBy = note.ModifiedBy;

            _unitOfWork.SuitabilityNotes().Update(noteToUpdate);
            _unitOfWork.Commit();

            return string.Empty;
        }

        private string InsertNote(SuitabilityNoteDTO note)
        {
            var noteToInsert = new SuitabilityNote
            {
                ContactId = note.ContactId,
                CreatedBy = note.UserId,
                CreatedDate = DateTime.Now,
                SuitabilityNoteTypeId = note.SuitabilityNoteTypeId,
                Text = note.Text
            };

            _unitOfWork.SuitabilityNotes().Insert(noteToInsert);
            _unitOfWork.Commit();

            return string.Empty;
        }

        private int GetTotalPages(int totalNumberOfItems, int pageSize)
        {
            return (totalNumberOfItems / pageSize) + (totalNumberOfItems % pageSize == 0 ? 0 : 1);
        }

        private string GetMessage(Exception exception)
        {
            var messages = new List<string>();

            while (exception != null)
            {
                messages.Add(exception.Message);
                exception = exception.InnerException;
            }

            return string.Join("; ", messages);
        }
    }
}
