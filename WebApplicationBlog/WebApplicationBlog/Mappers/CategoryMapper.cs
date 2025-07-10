using WebApplicationBlog.Models.Entities;
using WebApplicationBlog.Models.ViewModels.Admins;

namespace WebApplicationBlog.Mappers;

public static class CategoryMapper
{
    public static CategoryViewModel ToViewModel(CategoryModel model)
    {
        if (model == null) return null;
        return new CategoryViewModel
        {
            Name = model.Name,
            Slug = model.Slug
        };
    }

    public static CategoryModel ToEntity(CategoryViewModel viewModel)
    {
        if (viewModel == null) return null;
        return new CategoryModel
        {
            Name = viewModel.Name,
            Slug = viewModel.Slug
        };
    }

    public static void UpdateEntity(CategoryModel entity, CategoryViewModel viewModel)
    {
        if (entity == null || viewModel == null) return;
        entity.Name = viewModel.Name;
        entity.Slug = viewModel.Slug;
    }
}