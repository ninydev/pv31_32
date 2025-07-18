using Microsoft.AspNetCore.Identity;
using WebApplicationBlog.Models.Entities.MyNotes;

namespace WebApplicationBlog.Models.Entities.Auth;

public class MyIdentityUser: IdentityUser
{
    // Пример свойства для хранения аватара
    public string AvatarUrl { get; set; } = string.Empty;

    // Свойство для хранения даты регистрации
    public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
    
    // Свойство для хранения даты последнего входа
    public DateTime? LastLoginDate { get; set; }
    
    public List<PostModel> Posts { get; set; } = new();
    public List<CommentModel> Comments { get; set; } = new();
    public List<NoteEntity> Notes { get; set; } = new();
    
}