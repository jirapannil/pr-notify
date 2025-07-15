using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRNotify.Models
{
    [Table("department")]
    public class Department
    {
        [Key]
        [Column("dep_id")]
        public int DepartmentId { get; set; }

        [Required]
        [Column("dep_name")]
        public string DepartmentName { get; set; }

        [Column("status")]
        public string Status { get; set; }

        [Column("create_date")]
        public DateTime CreateDate { get; set; }

        [Column("update_date")]
        public DateTime UpdateDate { get; set; }
    }
}