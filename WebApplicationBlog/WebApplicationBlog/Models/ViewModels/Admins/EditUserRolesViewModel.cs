namespace WebApplicationBlog.Models.ViewModels.Admins;

public class EditUserRolesViewModel
{
    public string UserId { get; set; }
    public string UserName { get; set; }
    public List<RoleSelectionViewModel> Roles { get; set; }
}