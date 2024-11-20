using System.ComponentModel.DataAnnotations;

namespace PasswordHashing.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [StringLength(25, ErrorMessage = "Username length should not be more than 20 characters")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "PasswordHash is required")]
        public string PasswordHash { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address email should be in correct format")]
        public string Email { get; set; }
    }
}
