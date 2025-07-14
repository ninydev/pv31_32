using System.ComponentModel.DataAnnotations;

namespace WebApplicationBlog.Models.ViewModels.Admins;

public class TagViewModel
{
    [Required(ErrorMessage = "Name is required.")]
    [StringLength(256, ErrorMessage = "Name must be less than 256 characters.")]
    [MinLength(4, ErrorMessage = "Name must be at least 4 characters long.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Slug is required.")]
    [StringLength(256, ErrorMessage = "Slug must be less than 256 characters.")]
    [RegularExpression(@"^[a-z0-9-_]+$",
        ErrorMessage = "Slug can contain only lowercase letters, numbers, hyphens, and underscores.")]
    public string Slug { get; set; }
}