namespace WebApplication1.ViewModels
{
    public class PageBlogViewModel
    {
        public int CountPage { get; set; }
        public IEnumerable<BlogViewModel> Blogs { get; set; } = Enumerable.Empty<BlogViewModel>();
    }
}
