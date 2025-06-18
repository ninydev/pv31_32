using Microsoft.AspNetCore.Mvc;
using MyFirstMVCApp.Db;
using MyFirstMVCApp.Entities;
using MyFirstMVCApp.Mappers;
using MyFirstMVCApp.Models;

namespace MyFirstMVCApp.Controllers;

public class FormModelController : Controller
{
    private readonly ILogger<FormModelController> _logger;
    private readonly SqLiteDbContext _dbContext;
    
    public FormModelController(ILogger<FormModelController> logger, SqLiteDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }
    
    // GET
    public IActionResult Index()
    {
        return View(new FormViewModel());
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult SendFeedback(FormViewModel model)
    {
        ViewData["formData"] = model;
        
        if (!ModelState.IsValid)
        {
            _logger.LogWarning("Invalid form submission");
            FormEntity entity = FormMapper.ToEntity(model);
            _dbContext.Forms.Add(entity);
            _dbContext.SaveChanges();
        }
        return View("Index", model);
    }

}