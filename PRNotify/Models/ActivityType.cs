using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRNotify.Models
{
    [Table("activity_type")]
    public class ActivityType
    {
        [Key]
        [Column("act_type_id")]
        public int ActivityTypeId { get; set; }

        [Required]
        [Column("act_type")]
        public string TypeName { get; set; }

        [Column("status")]
        public string Status { get; set; }

        [Column("create_date")]
        public DateTime CreateDate { get; set; }

        [Column("update_date")]
        public DateTime UpdateDate { get; set; }
    }
}