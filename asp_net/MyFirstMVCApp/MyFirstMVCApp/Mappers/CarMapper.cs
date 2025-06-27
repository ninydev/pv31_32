using MyFirstMVCApp.Entities;
using MyFirstMVCApp.ViewModels;

namespace MyFirstMVCApp.Mappers;

public static class CarMapper
{
    // Маппинг из ViewModel в Entity с восстановлением цветов по id
    public static CarEntity ToEntity(CarViewModel model, IEnumerable<CarColorEntity> allColors)
    {
        var entity = new CarEntity
        {
            ManufacturerId = model.ManufacturerId,
            ModelName = model.ModelName,
            Year = model.Year,
            Price = model.Price,
            Colors = allColors.Where(c => model.ColorIds.Contains(c.Id)).ToList()
        };
        return entity;
    }

    // Старый вариант (без цветов) — можно удалить если не нужен
    public static CarEntity ToEntity(CarViewModel model)
    {
        return new CarEntity
        {
            ManufacturerId = model.ManufacturerId,
            ModelName = model.ModelName,
            Year = model.Year,
            Price = model.Price
            // Colors не заполняется
        };
    }

    // Маппинг из Entity в ViewModel (ColorIds из коллекции цветов)
    public static CarViewModel ToViewModel(CarEntity entity)
    {
        return new CarViewModel
        {
            ManufacturerId = entity.ManufacturerId,
            ModelName = entity.ModelName,
            Year = entity.Year,
            Price = entity.Price,
            ColorIds = entity.Colors?.Select(c => c.Id).ToArray() ?? Array.Empty<int>()
        };
    }
}