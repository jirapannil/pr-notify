using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRNotify.Models
{
    [Table("log")]
    public class Log
    {
        [Key]
        [Column("log_id")]
        public int LogId { get; set; }

        [Column("log")]
        public string LogDetail { get; set; }

        [Column("datetime")]
        public DateTime DateTime { get; set; }

        [Column("user_id")]
        public int? UserId { get; set; }

        [Column("status")]
        public string Status { get; set; }

        [Column("create_date")]
        public DateTime? CreateDate { get; set; }

        [Column("update_date")]
        public DateTime? UpdateDate { get; set; }

        [Column("log_type")]
        public string LogType { get; set; }

        public virtual User User { get; set; }
    }
}