using AutoMapper;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using ViewModel;
using WebStore.Interfaces.Services;
using WebStore.Services.Mapping;

namespace WebApplication1.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IProductData _productData;
        private readonly IMapper _mapper;
        private readonly IConfiguration _Configuration;

        public CatalogController(IProductData ProductData, IMapper mapper, IConfiguration Configuration)
        {
            _productData = ProductData;
            _mapper = mapper;
            _Configuration = Configuration;
        }

        public IActionResult Index([Bind("SectionId,BrandId,PageNumber,PageSize")] ProductFilter filter)
        {
            filter.PageSize ??= int.TryParse(_Configuration["CatalogPageSize"], out var page_size) ? page_size : null;

            var products = _productData.GetProducts(filter);

            return View(new CatalogViewModel
            {
                BrandId = filter.BrandId,
                SectionId = filter.SectionId,
                Products = products
                   .Items
                   .OrderBy(p => p.Order)
                   .Select(p => _mapper.Map<ProductViewModel>(p)),
                PageModel = new()
                {
                    Page = filter.PageNumber,
                    PageSize = filter.PageSize ?? 0,
                    TotalPages = products.PageCount,
                }
            });
        }

        public IActionResult Details(int Id)
        {
            var product = _productData.GetProductById(Id);
            if (product is null)
                return NotFound();

            return View(product.ToView());
        }
    }
}
