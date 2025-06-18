using MyFirstMVCApp.Entities;
using MyFirstMVCApp.Models;

namespace MyFirstMVCApp.Mappers;

public class FormMapper
{
    public static FormEntity ToEntity(FormViewModel vm)
    {
        return new FormEntity
        {
            Name = vm.Name,
            Age = vm.Age,
            Email = vm.Email,
            Message = vm.Message,
            CreatedAt = DateTime.UtcNow
        };
    }
    
    public static FormViewModel ToViewModel(FormEntity entity)
    {
        return new FormViewModel
        {
            Name = entity.Name,
            Age = entity.Age,
            Email = entity.Email,
            Message = entity.Message
        };
    }
}