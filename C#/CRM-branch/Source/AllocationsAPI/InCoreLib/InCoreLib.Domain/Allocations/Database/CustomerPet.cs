using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("CustomerPet")]
    public partial class CustomerPet
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PetId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerApplicationID { get; set; }

        public int NumberOfPet { get; set; }

        public bool PetIsMoving { get; set; }

        [StringLength(100)]
        public string LastUpdatedUserName { get; set; }
    }
}
