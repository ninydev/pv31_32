using MyFirstMVCApp.Entities;
using MyFirstMVCApp.ViewModels;

namespace MyFirstMVCApp.Mappers;

public static class CarMapper
{
    public static CarEntity ToEntity(CarViewModel model)
    {
        return new CarEntity
        {
            ManufacturerId = model.ManufacturerId,
            ModelName = model.ModelName,
            Year = model.Year,
            Color = model.Color,
            Price = model.Price
        };
    }

    public static CarViewModel ToViewModel(CarEntity entity)
    {
        return new CarViewModel
        {
            ManufacturerId = entity.ManufacturerId,
            ModelName = entity.ModelName,
            Year = entity.Year,
            Color = entity.Color,
            Price = entity.Price
        };
    }
}