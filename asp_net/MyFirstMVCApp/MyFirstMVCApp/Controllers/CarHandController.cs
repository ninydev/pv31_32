using Microsoft.AspNetCore.Mvc;
using MyFirstMVCApp.Db;
using MyFirstMVCApp.Entities;

namespace MyFirstMVCApp.Controllers;

public class CarHandController : Controller
{
    private readonly SqLiteDbContext _dbContext;

    public CarHandController(SqLiteDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    /// <summary>
    /// Мне нужен метод, который будет возвращать форму для создания нового автомобиля.
    /// По запросу GET на /CarHand/Create я получаю форму для создания нового автомобиля.
    /// </summary>
    /// <returns>Страница с формой</returns>
    [HttpGet]
    public IActionResult Create()
    {
        CarEntity newCar = new CarEntity();
        return View(newCar);
    }
    
    /// <summary>
    /// Мне нужен метод, который будет обрабатывать POST-запрос на создание нового автомобиля.
    /// Я должен отправить данные формы на сервер, и если данные валидны,
    /// то новый автомобиль должен быть добавлен в базу данных.
    ///
    /// Поэтому мне нужно два метода:
    /// - один для обработки GET-запроса, который возвращает форму,
    /// - другой для обработки POST-запроса, который сохраняет данные в базу данных.
    /// </summary>
    /// <param name="newCar">Данные для нового авто</param>
    /// <returns>Или переход на главную, или форму с ошибками</returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(CarEntity newCar)
    {
        if (ModelState.IsValid)
        {
            _dbContext.Cars.Add(newCar);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
        
        return View(newCar);
    }
    
    /// <summary>
    /// Мне так же нужно 2 запроса на READ:
    /// - один для получения списка всех автомобилей,
    /// - другой для получения информации об одном автомобиле по его ID.
    /// </summary>
    /// <returns>Страница со всеми автомобилями</returns>
    [HttpGet]
    public IActionResult Index()
    {
        return View(_dbContext.Cars.ToList());
    }
    
    
    
    
    
    
    
}