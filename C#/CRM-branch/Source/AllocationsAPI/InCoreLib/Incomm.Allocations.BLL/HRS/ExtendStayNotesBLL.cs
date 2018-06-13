using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Incomm.Allocations.BLL.Interfaces;
using InCoreLib.DAL;
using Incomm.Allocations.BLL.DTOs;

namespace Incomm.Allocations.BLL
{
    public class ExtendStayNotesBLL:  IExtendCaseNotesBLL
    {
        private IUnitOfWork _unitOfWork;
        public ExtendStayNotesBLL() : this(new UnitOfWork())
        {
        }

        public ExtendStayNotesBLL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<tblCaseNoteDTO> GetHRSExtendStayNotes(string CurrentUserEmail)
        {
            var result = _unitOfWork.CaseNotes().Select(x => x.CaseNoteType == "HRSExtendStay" && x.CaseNoteUserID == CurrentUserEmail);
            var result2 = Mapper.Map<List<tblCaseNoteDTO>>(result.ToList());
            return result2;
        }
    }
}