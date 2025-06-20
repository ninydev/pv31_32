using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFirstMVCApp.Entities;

[Table("FormEntities")]
public class FormEntity
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  [Column("Id")]
  public int Id { get; set; }
  
  [Column("MyThinkAboutUser", TypeName = "nvarchar(256)")]
  public string MyThinkAboutUser { get; set; }

  [Required]
  [StringLength(50)]
  [Column("Name", TypeName = "nvarchar(50)")]
  public string Name { get; set; }

  [Required]
  [Column("Age")]
  public int Age { get; set; }

  [Required]
  [StringLength(100)]
  [Column("Email", TypeName = "nvarchar(100)")]
  public string Email { get; set; }

  [Required]
  [StringLength(500)]
  [Column("Message", TypeName = "nvarchar(500)")]
  public string Message { get; set; }

  [Required]
  [Column("CreatedAt")]
  public DateTime CreatedAt { get; set; }
}