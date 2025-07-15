using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRNotify.Models
{
    [Table("activity_img")]
    public class ActivityImg
    {
        [Key]
        [Column("act_img_id")]
        public int ActivityImgId { get; set; }

        [Column("act_id")]
        public int ActivityId { get; set; }

        [Column("act_img")]
        public string ImgName { get; set; }

        [Column("act_img_path")]
        public string ImgPath { get; set; }

        [Column("status")]
        public string Status { get; set; }

        [Column("create_date")]
        public DateTime CreateDate { get; set; }

        [Column("update_date")]
        public DateTime UpdateDate { get; set; }

        public virtual Activity Activity { get; set; }
    }
}