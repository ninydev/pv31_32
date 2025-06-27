using System.ComponentModel.DataAnnotations;

namespace MyFirstMVCApp.ViewModels;

public class CarViewModel
{
    [Required(ErrorMessage = "Выберите производителя")]
    [Display(Name = "Производитель", Description = "Выберите производителя автомобиля из списка")]
    public int ManufacturerId { get; set; }

    [Required(ErrorMessage = "Укажите модель")]
    [StringLength(50, ErrorMessage = "Название модели не должно превышать 50 символов")]
    [Display(Name = "Модель", Description = "Название модели автомобиля")]
    public string ModelName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Укажите год выпуска")]
    [Range(1900, 2100, ErrorMessage = "Год выпуска должен быть в диапазоне от 1900 до 2100")]
    [Display(Name = "Год выпуска", Description = "Год выпуска автомобиля")]
    public int Year { get; set; }

    [Required(ErrorMessage = "Укажите хотя бы один цвет")]
    [Display(Name = "Цвета", Description = "Выберите один или несколько цветов автомобиля")]
    public int[] ColorIds { get; set; } = Array.Empty<int>();

    [Required(ErrorMessage = "Укажите цену")]
    [Range(0, 10000000, ErrorMessage = "Цена должна быть положительной и не превышать 10 000 000")]
    [Display(Name = "Цена", Description = "Стоимость автомобиля в рублях")]
    public decimal Price { get; set; }
}