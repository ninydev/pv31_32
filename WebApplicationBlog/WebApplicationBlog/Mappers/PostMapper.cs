using WebApplicationBlog.Models.Entities;
using WebApplicationBlog.Models.ViewModels.Authors;

namespace WebApplicationBlog.Mappers;

public static class PostMapper
{
    public static PostViewModel ToViewModel(PostModel model)
    {
        if (model == null) return null;
        return new PostViewModel
        {
            Title = model.Title,
            Slug = model.Slug,
            Content = model.Content,
            CategoryId = model.CategoryId,
            TagIds = model.Tags?.Select(t => t.Id).ToList() ?? new List<int>(),
            IsPublished = model.IsPublished
        };
    }

    public static void UpdateEntity(PostModel entity, PostViewModel viewModel, List<TagModel> tags)
    {
        if (entity == null || viewModel == null) return;
        entity.Title = viewModel.Title;
        entity.Slug = viewModel.Slug;
        entity.Content = viewModel.Content;
        entity.CategoryId = viewModel.CategoryId;
        entity.IsPublished = viewModel.IsPublished;
        entity.Tags = tags ?? new List<TagModel>();
    }

    public static PostModel ToEntity(PostViewModel viewModel, string authorId, List<TagModel> tags)
    {
        if (viewModel == null) return null;
        return new PostModel
        {
            Title = viewModel.Title,
            Slug = viewModel.Slug,
            Content = viewModel.Content,
            CategoryId = viewModel.CategoryId,
            IsPublished = viewModel.IsPublished,
            AuthorId = authorId,
            Tags = tags ?? new List<TagModel>(),
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
    }
}