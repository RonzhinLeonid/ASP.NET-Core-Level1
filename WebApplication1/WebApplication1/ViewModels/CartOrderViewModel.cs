namespace WebApplication1.ViewModels
{
    public class CartOrderViewModel
    {
        public CartViewModel Cart { get; set; } = null!;

        public OrderViewModel Order { get; set; } = new();
    }
}
