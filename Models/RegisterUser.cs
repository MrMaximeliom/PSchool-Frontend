using System.ComponentModel.DataAnnotations;

namespace TestBlazor.Models
{
    public class RegisterUser
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
            public string Email { get; set; } = string.Empty;

            [Required]
            public string Password { get; set; } = string.Empty;

        [Required]
        public string PhoneNumber { get; set; } = string.Empty;

        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Try again !")]
        public string ConfirmPassword { get; set; } = string.Empty;

        public string Username { get; set; } = string.Empty;


    }
}
