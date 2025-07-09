using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationBlog.Models.Entities;

[Index(nameof(Slug), IsUnique = true)]
public class TagModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    [Column("name", TypeName = "nvarchar(256)")]
    public string Name { get; set; }
    
    [Required]
    [Column("slug", TypeName = "nvarchar(256)")]
    public string Slug { get; set; }
    
    public List<PostModel> Posts { get; set; } = new List<PostModel>();

}