using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationBlog.Models.Entities;

[Index(nameof(Slug), IsUnique = true)]
[Index(nameof(AuthorId))]
[Index(nameof(CategoryId))]
[Index(nameof(CreatedAt))]
[Index(nameof(IsPublished))]
[Index(nameof(IsDeleted))]
public class PostModel
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id { get; set; }

  [Required]
  [ForeignKey(nameof(Author))]
  [Column("author_id", TypeName = "nvarchar(450)")]
  public string AuthorId { get; set; }
  public ProfileModel Author { get; set; }

  [Required]
  [Column("slug", TypeName = "nvarchar(256)")]
  [MaxLength(256)]
  public string Slug { get; set; }

  [Required]
  [Column("title", TypeName = "nvarchar(256)")]
  [MaxLength(256)]
  public string Title { get; set; }

  [Column("thumbnail", TypeName = "nvarchar(512)")]
  [MaxLength(512)]
  public string Thumbnail { get; set; }

  [Column("content", TypeName = "text")]
  public string Content { get; set; }

  [Column("created_at")]
  public DateTime CreatedAt { get; set; }  = DateTime.UtcNow;

  [Column("updated_at")]
  public DateTime UpdatedAt { get; set; }  = DateTime.UtcNow;

  [Required]
  [ForeignKey(nameof(Category))]
  [Column("category_id")]
  public int CategoryId { get; set; }
  public CategoryModel Category { get; set; }

  public List<TagModel> Tags { get; set; } = new List<TagModel>();
  public List<CommentModel> Comments { get; set; } = new List<CommentModel>();

  [Column("view_count")]
  public int ViewCount { get; set; } = 0;

  [Column("comment_count")]
  public int CommentCount { get; set; } = 0;

  [Column("is_published")]
  public bool IsPublished { get; set; } = false;

  [Column("is_deleted")]
  public bool IsDeleted { get; set; } = false;
}