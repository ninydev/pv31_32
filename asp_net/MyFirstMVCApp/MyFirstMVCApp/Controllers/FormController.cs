using Microsoft.AspNetCore.Mvc;

namespace MyFirstMVCApp.Controllers;

public class FormController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult SendFeedback(string name, string email, string message)
    {
        // Process the form data here
        ViewData["MessageData"] = $"Received Name: {name}, Email: {email}, Message: {message}";
        ViewData["formData"] = new { Name = name, Email = email, Message = message };
        ViewData["Name"] = name;
        ViewData["Email"] = email;
        ViewData["Message"] = message;
        
        // Optionally, you can redirect to another action or return a view
        return View("Index");
    }

}