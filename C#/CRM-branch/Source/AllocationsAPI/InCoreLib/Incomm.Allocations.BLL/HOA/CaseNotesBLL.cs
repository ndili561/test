using AutoMapper;
using Incomm.Allocations.BLL.Interfaces.HOA;
using Incomm.Allocations.DTO;
using InCoreLib.DAL;
using System.Collections.Generic;
using System.Linq;

namespace Incomm.Allocations.BLL.HOA
{
    public class CaseNotesBLL : ICaseNotesBLL
    {
        private readonly IUnitOfWork _unitOfWork;

        public CaseNotesBLL() : this(new UnitOfWork())
        {
        }

        public CaseNotesBLL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IList<HOACaseNoteDTO> GetCaseNotes(int caseRefNumber)
        {
            var hoaCaseNoteDtos = _unitOfWork.TblCaseNotes()
                .Select(a => a.CaseRefNumber == caseRefNumber)
                .AsEnumerable()
                .Select(Mapper.Map<HOACaseNoteDTO>)
                .ToList();

            var types = GetCaseNoteTypes();

            foreach (var hoaCaseNoteDto in hoaCaseNoteDtos)
            {
                hoaCaseNoteDto.HoaCaseNoteTypeDto =
                    types.SingleOrDefault(t => t.CaseNoteType == hoaCaseNoteDto.CaseNoteType);
            }

            return hoaCaseNoteDtos;
        }

        public IList<HOACaseNoteTypeDTO> GetCaseNoteTypes()
        {
            return _unitOfWork.LstCaseNoteTypes()
                .Select()
                .AsEnumerable()
                .Select(Mapper.Map<HOACaseNoteTypeDTO>)
                .ToList();
        }
    }
}