using ViewModel;

namespace DTO
{
    public class CreateOrderDTO
    {
        public OrderViewModel Order { get; set; } = null!;

        public IEnumerable<OrderItemDTO> Items { get; set; } = null!;
    }
}
