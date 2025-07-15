using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRNotify.Models
{
    [Table("notification")]
    public class Notification
    {
        [Key]
        [Column("noti_id")]
        public int NotificationId { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("message")]
        public string Message { get; set; }

        [Column("url")]
        public string Url { get; set; }

        [Column("is_read")]
        public bool? IsRead { get; set; }

        [Column("create_date")]
        public DateTime CreateDate { get; set; }

        public virtual User User { get; set; }
    }
}