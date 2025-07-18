using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFirstMVCApp.Controllers.Results;
using MyFirstMVCApp.Db;
using MyFirstMVCApp.Entities;
using MyFirstMVCApp.ViewModels;
using MyFirstMVCApp.Mappers;

namespace MyFirstMVCApp.Controllers;

public class CarHandController : Controller
{
    private readonly SqLiteDbContext _dbContext;
    private readonly ILogger<CarHandController> _logger;

    public CarHandController(SqLiteDbContext dbContext , ILogger<CarHandController> logger)
    {
        _logger = logger;   
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
        ViewData["Manufacturers"] = _dbContext.Manufacturers.ToList();
        ViewData["Colors"] = _dbContext.CarColorEntity.ToList();
        return View(new CarViewModel());
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
    public IActionResult Create(CarViewModel model)
    {
        if (ModelState.IsValid)
        {
            var allColors = _dbContext.CarColorEntity.ToList();
            var newCar = CarMapper.ToEntity(model, allColors);
            _dbContext.Cars.Add(newCar);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
        foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
        {
            _logger.LogError(error.ErrorMessage);
        }
        ViewData["Manufacturers"] = _dbContext.Manufacturers.ToList();
        ViewData["Colors"] = _dbContext.CarColorEntity.ToList();
        return View(model);
    }
    
    
    /// <summary>
    /// Мне так же нужно 2 запроса на READ:
    /// - один для получения списка всех автомобилей,
    /// - другой для получения информации об одном автомобиле по его ID.
    /// </summary>
    /// <returns>Страница со всеми автомобилями</returns>
    [HttpGet]
    public IActionResult Index([FromQuery] PaginateViewModel paginate)
    {
        // IEnumerable<MyFirstMVCApp.Entities.CarEntity> cars = 
        //     _dbContext
        //         .Cars
        //         .Include(c => c.Manufacturer)
        //         .Include(c=> c.Colors)
        //         .ToList();
        
        
        var query = _dbContext
            .Cars
            .Include(c => c.Manufacturer)
            .Include(c => c.Colors);

        var totalItems = query.Count();
        
        var cars = query
            .Skip((paginate.Page - 1) * paginate.PageSize)
            .Take(paginate.PageSize)
            .ToList();

        var result = new PagedResult<CarEntity>
        {
            Items = cars,
            Page = paginate.Page,
            PageSize = paginate.PageSize,
            TotalItems = totalItems
        };
        return View(result);
    }
    
    /// <summary>
    /// Построение страницы с информацией об автомобиле по ID
    /// </summary>
    /// <param name="id">ID автомобиля</param>
    /// <returns>Страница с 1 автомобилем</returns>
    public IActionResult ReadById(int id)
    {
        CarEntity carDB = 
            _dbContext.Cars
                .Include(c => c.Manufacturer)
                .Include(c => c.Colors)
                .FirstOrDefault(c => c.Id == id);
        
        if (carDB == null)
        {
            _logger.LogWarning($"Car with ID {id} not found.");
            return NotFound();
        }
        
        // CarViewModel carVM = CarMapper.ToViewModel(carDB);
        
        return View(carDB);
    }
}
