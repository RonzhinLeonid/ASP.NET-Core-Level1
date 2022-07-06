using AutoMapper;
using DataLayer;
using ViewModel;
using WebStore.Interfaces.Services;

namespace WebStore.Services.Services
{
    public class CartService : ICartService
    {
        private readonly IProductData _ProductData;
        private readonly ICartStore _CartStore;
        private readonly IMapper _mapper;

        public CartService(IProductData ProductData, ICartStore CartStore, IMapper mapper)
        {
            _ProductData = ProductData;
            _CartStore = CartStore;
            _mapper = mapper;
        }

        public void Add(int Id)
        {
            var cart = _CartStore.Cart;
            cart.Add(Id);
            _CartStore.Cart = cart;
        }

        public void Decrement(int Id)
        {
            var cart = _CartStore.Cart;
            cart.Decrement(Id);
            _CartStore.Cart = cart;
        }

        public void Remove(int Id)
        {
            var cart = _CartStore.Cart;
            cart.Remove(Id);
            _CartStore.Cart = cart;
        }

        public void Clear()
        {
            var cart = _CartStore.Cart;
            cart.Clear();
            _CartStore.Cart = cart;
        }

        public CartViewModel GetViewModel()
        {
            var cart = _CartStore.Cart;

            var products = _ProductData.GetProducts(new()
            {
                Ids = cart.Items.Select(item => item.ProductId).ToArray(),
            });

            var products_views = products.Select(x => _mapper.Map<Product, ProductViewModel>(x)).ToDictionary(p => p.Id);

            return new()
            {
                Items = cart.Items
                   .Where(item => products_views.ContainsKey(item.ProductId))
                   .Select(item => (products_views[item.ProductId], item.Quantity))!,
            };
        }
    }
}
