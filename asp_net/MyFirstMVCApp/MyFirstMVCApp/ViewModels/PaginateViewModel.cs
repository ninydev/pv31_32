namespace MyFirstMVCApp.ViewModels;

public class PaginateViewModel
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}