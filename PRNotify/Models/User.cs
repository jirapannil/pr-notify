using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRNotify.Models
{
    public enum UserStatus { Active, Inactive }

    [Table("user")]
    public class User
    {
        [Key]
        [Column("user_id")]
        public int UserId { get; set; }

        [Required]
        [Column("username")]
        public string Username { get; set; }

        [Required]
        [Column("password")]
        public string Password { get; set; }

        [Column("title_id")]
        public int TitleId { get; set; }

        [Required]
        [Column("fname")]
        public string FirstName { get; set; }

        [Required]
        [Column("lname")]
        public string LastName { get; set; }

        [Column("phone_number")]
        public string PhoneNumber { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("dep_id")]
        public int DepartmentId { get; set; }

        [Column("role_id")]
        public int RoleId { get; set; }

        [Column("status")]
        public UserStatus Status { get; set; }

        [Column("create_date")]
        public DateTime CreateDate { get; set; }

        [Column("update_date")]
        public DateTime UpdateDate { get; set; }

        // Navigation properties
        public virtual Department Department { get; set; }
        public virtual Role Role { get; set; }
        public virtual Title Title { get; set; }
    }
}