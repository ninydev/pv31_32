using System.ComponentModel.DataAnnotations;

namespace WebApplicationBlog.Models.ViewModels.Authors;

public class PostViewModel
{
    [Required]
    [StringLength(256, ErrorMessage = "Title must be less than 256 characters.")]
    public string Title { get; set; }

    [Required]
    [StringLength(256, ErrorMessage = "Slug must be less than 256 characters.")]
    [RegularExpression(@"^[a-z0-9-_]+$",
        ErrorMessage = "Slug can contain only lowercase letters, numbers, hyphens, and underscores.")]
    public string Slug { get; set; }

    [Required(ErrorMessage = "Content is required.")]
    public string Content { get; set; }

    [Required(ErrorMessage = "Category is required.")]
    public int CategoryId { get; set; }

    public List<int> TagIds { get; set; } = new();

    public bool IsPublished { get; set; } = false;

    [Display(Name = "Thumbnail (preview image)")]
    public IFormFile Thumbnail { get; set; }
}