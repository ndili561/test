using System;
using System.ComponentModel.DataAnnotations;
using InCoreLib.Helpers;

namespace Incomm.Allocations.BLL.DTOs
{
    public abstract class BaseObjectDto
    {
        protected BaseObjectDto()
        {
            
        }
        public string CreatedBy { get; set; }
        [Display(Name = "Date Created")]
        public DateTime CreatedDate { get; set; }

        public string UserId { get; set; }
        public string UserIPAddress { get; set; }

        //Used to check concurrency
        public byte[] RowVersion { get; set; }
        [Display(Name = "Modified By")]
        public string ModifiedBy { get; set; }

        [Display(Name = "Modified By")]
        public string ModifiedByName
        {
            get
            {
                return ModifiedBy.GetFullName();
            }
        } 
        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate { get; set; }

        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }
    }

}