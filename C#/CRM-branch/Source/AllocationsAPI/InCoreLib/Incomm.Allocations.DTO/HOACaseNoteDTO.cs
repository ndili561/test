using System;
using Incomm.Allocations.BLL.DTOs;

namespace Incomm.Allocations.DTO
{
    public class HOACaseNoteDTO
    {
        public HOACaseNoteTypeDTO HoaCaseNoteTypeDto { get; set; }
        public string CaseNote { get; set; }
        public bool? CaseNoteConfidentialFlag { get; set; }
        public DateTime? CaseNoteConfidentialFlagDateSet { get; set; }
        public string CaseNoteConfidentialFlagUserID { get; set; }
        public DateTime? CaseNoteDate { get; set; }
        public int CaseNoteIndex { get; set; }
        public DateTime? CaseNoteLastEditedDateTime { get; set; }
        public string CaseNoteType { get; set; }
        public string CaseNoteUserID { get; set; }
        public int? CaseRefNumber { get; set; }
        public int? QstnID { get; set; }
        public int? QstnrSectionID { get; set; }
        public int? QstnrSubSectionID { get; set; }
        public byte[] upsize_ts { get; set; }
        public virtual string UserId { get; set; }
        public virtual string UserIPAddress { get; set; }
    }
}