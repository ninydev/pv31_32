using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplicationBlog.Models.ViewModels.Admins;

// если есть модель User

namespace WebApplicationBlog.Controllers.Admins;

[Authorize(Roles = "Admin")]
[Route("admin/user-roles")]
public class AdminUserRolesController : Controller
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<IdentityUser> _userManager;

    public AdminUserRolesController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    // GET: admin/user-roles
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var users = _userManager.Users.ToList();
        var userRolesView = new List<UserRolesViewModel>();
        foreach (var user in users)
        {
            var roles = await _userManager.GetRolesAsync(user);
            userRolesView.Add(new UserRolesViewModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                Roles = roles.ToList()
            });
        }

        return View(userRolesView);
    }

    // GET: admin/user-roles/edit/{userId}
    [HttpGet("edit/{userId}")]
    public async Task<IActionResult> Edit(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null) return NotFound();

        var userRoles = await _userManager.GetRolesAsync(user);
        var allRoles = _roleManager.Roles.Select(r => r.Name).ToList();

        var model = new EditUserRolesViewModel
        {
            UserId = user.Id,
            UserName = user.UserName,
            Roles = allRoles.Select(role => new RoleSelectionViewModel
            {
                RoleName = role,
                Selected = userRoles.Contains(role)
            }).ToList()
        };
        return View(model);
    }

    // POST: admin/user-roles/edit/{userId}
    [HttpPost("edit/{userId}")]
    public async Task<IActionResult> Edit(string userId, EditUserRolesViewModel model)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null) return NotFound();

        var userRoles = await _userManager.GetRolesAsync(user);
        var selectedRoles = model.Roles.Where(r => r.Selected).Select(r => r.RoleName).ToList();

        var result = await _userManager.AddToRolesAsync(user, selectedRoles.Except(userRoles));
        if (!result.Succeeded)
        {
            ModelState.AddModelError("", "Failed to add roles");
            return View(model);
        }

        result = await _userManager.RemoveFromRolesAsync(user, userRoles.Except(selectedRoles));
        if (!result.Succeeded)
        {
            ModelState.AddModelError("", "Failed to remove roles");
            return View(model);
        }

        return RedirectToAction(nameof(Index));
    }

    // GET: admin/user-roles/delete/{userId}/{roleName}
    [HttpGet("delete/{userId}/{roleName}")]
    public async Task<IActionResult> Delete(string userId, string roleName)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null) return NotFound();

        var result = await _userManager.RemoveFromRoleAsync(user, roleName);
        if (!result.Succeeded) return BadRequest("Failed to remove role");
        return RedirectToAction(nameof(Index));
    }

    // GET: admin/user-roles/details/{userId}
    [HttpGet("details/{userId}")]
    public async Task<IActionResult> Details(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null) return NotFound();

        var roles = await _userManager.GetRolesAsync(user);
        var model = new UserRolesViewModel
        {
            UserId = user.Id,
            UserName = user.UserName,
            Roles = roles.ToList()
        };
        return View(model);
    }
}

// Вспомогательные модели для View