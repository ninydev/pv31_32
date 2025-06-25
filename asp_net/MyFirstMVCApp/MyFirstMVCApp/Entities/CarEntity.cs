using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFirstMVCApp.Entities;

[Table("Cars")]
public class CarEntity
{
    // Navigation property to ManufacturerEntity
    // ONE CarEntity belongs to ONE ManufacturerEntity
    public ManufacturerEntity Manufacturer { get; set; }
    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("Id")]
    public int Id { get; set; }
    
    [Required]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Model must be between 2 and 50 characters.")]
    public string ModelName { get; set; } = string.Empty;
    public int Year { get; set; }
    public string Color { get; set; } = string.Empty;
    public decimal Price { get; set; }
    
    // [Key]
    // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    // [Column("Id")]
    // public Guid Id { get; set; }
}