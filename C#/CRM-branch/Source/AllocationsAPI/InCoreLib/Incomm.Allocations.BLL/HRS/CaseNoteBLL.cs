using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.OData.Query;
using AutoMapper;
using Incomm.Allocations.BLL.Interfaces;
using InCoreLib.DAL;
using Incomm.Allocations.BLL.DTOs;
using InCoreLib.Domain.Allocations.Database;

namespace Incomm.Allocations.BLL
{
    public class CaseNoteBLL :  ICaseNoteBLL
    {
        private IUnitOfWork _unitOfWork;
        public CaseNoteBLL() : this(new UnitOfWork())
        {
        }

        public CaseNoteBLL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<tblCaseNoteDTO> GetEndOfServiceNotes(ODataQueryOptions<tblCaseNote> options)
        {
            var caseNote =
                options.ApplyTo(_unitOfWork.CaseNotes().Select(x => x.CaseNoteType == "HRSEndOfService").AsQueryable());
           return Mapper.Map<List<tblCaseNoteDTO>>(caseNote);
        }

        public tblCaseNoteDTO PostCaseNote(tblCaseNoteDTO item)
        {
            var entityTobeSave = Mapper.Map<tblCaseNote>(item);
            _unitOfWork.CaseNotes().Insert(entityTobeSave);
            _unitOfWork.Commit(entityTobeSave.UserId,entityTobeSave.UserIPAddress);
          return  item = Mapper.Map<tblCaseNoteDTO>(entityTobeSave);
        }
    }
}