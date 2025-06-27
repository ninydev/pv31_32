using System.ComponentModel.DataAnnotations;

namespace MyFirstMVCApp.Models;

public class FormViewModel
{
    [Required(ErrorMessage = "Name is required.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters.")]
    [Display(Name = "Full Name", Description = "Enter your full name (2-50 characters).")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Age is required.")]
    [Range(18, 120, ErrorMessage = "Age must be between 18 and 120.")]
    [Display(Name = "Age", Description = "Enter your age (18-120).")]
    public int Age { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address format.")]
    [Display(Name = "Email Address", Description = "Enter a valid email address.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Message is required.")]
    [StringLength(500, MinimumLength = 10, ErrorMessage = "Message must be between 10 and 500 characters.")]
    [Display(Name = "Message", Description = "Enter your message (10-500 characters).")]
    public string Message { get; set; }
}