using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationBlog.Models.Entities.MyNotes;

public class NoteEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    // Фиксированный идентификатор автора заметки
    public string AuthorId { get; set; }
    
    
}