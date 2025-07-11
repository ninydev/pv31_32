using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationBlog.Models.Entities;

public class CommentModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [ForeignKey(nameof(Author))]
    [Column("author_id", TypeName = "nvarchar(450)")]
    public string AuthorId { get; set; }

    public ProfileModel Author { get; set; }

    [Column("content", TypeName = "text")] public string Content { get; set; }

    public PostModel Post { get; set; }

    [Column("created_at")] public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}