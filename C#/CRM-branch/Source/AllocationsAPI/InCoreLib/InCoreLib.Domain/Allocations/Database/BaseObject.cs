using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    public abstract class BaseObject 
    {
        [MaxLength(256)]
        [SkipTracking]
        public virtual string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        [NotMapped]
        [SkipTracking]
        public virtual string UserId { get; set; }

        [NotMapped]
        [SkipTracking]
        public virtual string UserIPAddress { get; set; }

        //Used to check concurrency
        [ConcurrencyCheck, Timestamp]
        [SkipTracking]
        public virtual byte[] RowVersion { get; set; }

        [MaxLength(256)]
        [SkipTracking]
        public virtual string ModifiedBy { get; set; }

        [SkipTracking]
        public virtual DateTime? ModifiedDate { get; set; }

        [NotMapped]
        [SkipTracking]
        public virtual string ErrorMessage { get; set; }

    }

}