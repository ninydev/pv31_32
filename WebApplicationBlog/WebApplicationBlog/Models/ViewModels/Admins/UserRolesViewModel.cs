namespace WebApplicationBlog.Models.ViewModels.Admins;

public class UserRolesViewModel
{
    public string UserId { get; set; }
    public string UserName { get; set; }
    public List<string> Roles { get; set; }
}