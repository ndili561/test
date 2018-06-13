using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    public partial class tblSelectedColumn
    {
        [Key]
        [Column(Order = 0)]
        public int RecID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(150)]
        public string UserID { get; set; }

        [StringLength(150)]
        public string TableName { get; set; }

        [StringLength(150)]
        public string QueryName { get; set; }

        [StringLength(150)]
        public string WorksheetName { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(250)]
        public string ColumnName { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime DateSelected { get; set; }

        [StringLength(150)]
        public string Editing { get; set; }
    }
}
