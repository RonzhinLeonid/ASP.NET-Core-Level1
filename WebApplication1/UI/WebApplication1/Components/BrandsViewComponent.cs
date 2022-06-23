using Microsoft.AspNetCore.Mvc;
using ViewModel;
using WebStore.Interfaces.Services;

namespace WebApplication1.Components
{
    public class BrandsViewComponent : ViewComponent
    {
        private readonly IProductData _ProductData;

        public BrandsViewComponent(IProductData ProductData) => _ProductData = ProductData;

        public IViewComponentResult Invoke() => View(GetBrands());

        private IEnumerable<BrandViewModel> GetBrands() =>
            _ProductData.GetBrands()
               .OrderBy(b => b.Order)
               .Select(b => new BrandViewModel
               {
                   Id = b.Id,
                   Name = b.Name,
               });
    }
}
