namespace ViewModel
{
    public class BlogViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string User { get; set; } = null!;
        public DateTime Date { get; set; }
        public double Rating { get; set; }
        public string ImageUrl { get; set; } = null!;
        public string Text { get; set; } = null!;
    }
}
