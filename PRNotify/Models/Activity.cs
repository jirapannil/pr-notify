using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRNotify.Models
{
    public enum ActivityStatus { pending, in_progress, completed }
    public enum RecordStatus { Active, Inactive }

    [Table("activity")]
    public class Activity
    {
        [Key]
        [Column("act_id")]
        public int ActivityId { get; set; }

        [Required]
        [Column("user_id")]
        public int UserId { get; set; }

        [Required]
        [Column("act_type_id")]
        public int ActivityTypeId { get; set; }

        [Required]
        [Column("act_type_detail")]
        public string ActivityTypeDetail { get; set; }

        [Required]
        [Column("act_date")]
        public DateTime ActivityDate { get; set; }

        [Required]
        [Column("act_time")]
        public TimeSpan ActivityTime { get; set; }

        [Required]
        [Column("act_location")]
        public string ActivityLocation { get; set; }

        [Required]
        [Column("act_name")]
        public string ActivityName { get; set; }

        [Column("act_objective")]
        public string ActivityObjective { get; set; }

        [Column("act_description")]
        public string ActivityDescription { get; set; }

        [Column("num_participants")]
        public int? NumParticipants { get; set; }

        [Column("participating_agencies")]
        public string ParticipatingAgencies { get; set; }

        [Column("act_status_in_progress")]
        public DateTime? StatusInProgress { get; set; }

        [Column("act_status_completed")]
        public DateTime? StatusCompleted { get; set; }

        [Column("act_status")]
        public ActivityStatus Status { get; set; }

        [Column("status")]
        public RecordStatus RecordStatus { get; set; }

        [Column("create_date")]
        public DateTime CreateDate { get; set; }

        [Column("update_date")]
        public DateTime UpdateDate { get; set; }

        // Navigation properties
        public virtual User User { get; set; }
        public virtual ActivityType ActivityType { get; set; }
    }
}