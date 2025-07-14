using WebApplicationBlog.Models.Entities;
using WebApplicationBlog.Models.ViewModels.Admins;

namespace WebApplicationBlog.Mappers;

public static class TagMapper
{
    public static TagViewModel ToViewModel(TagModel tag)
    {
        if (tag == null) return null;
        return new TagViewModel
        {
            Name = tag.Name,
            Slug = tag.Slug
        };
    }

    public static TagModel ToEntity(TagViewModel viewModel)
    {
        if (viewModel == null) return null;
        return new TagModel
        {
            Name = viewModel.Name,
            Slug = viewModel.Slug
        };
    }

    public static void UpdateEntity(TagModel tag, TagViewModel viewModel)
    {
        if (tag == null || viewModel == null) return;
        tag.Name = viewModel.Name;
        tag.Slug = viewModel.Slug;
    }
}