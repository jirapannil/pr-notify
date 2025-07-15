using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRNotify.Models
{
    [Table("title")]
    public class Title
    {
        [Key]
        [Column("title_id")]
        public int TitleId { get; set; }

        [Column("title_th")]
        public string Thai { get; set; }

        [Column("title_eng")]
        public string English { get; set; }

        [Column("status")]
        public string Status { get; set; }

        [Column("create_date")]
        public DateTime CreateDate { get; set; }

        [Column("update_date")]
        public DateTime UpdateDate { get; set; }
    }
}