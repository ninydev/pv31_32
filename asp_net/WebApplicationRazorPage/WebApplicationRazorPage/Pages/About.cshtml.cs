using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplicationRazorPage.Pages;

public class About : PageModel
{
    public void OnGet()
    {
        ViewData["MessageData"] = "Hello ViewData from About Page!";
    }
}