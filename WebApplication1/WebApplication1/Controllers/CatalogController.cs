using AutoMapper;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services.Interfaces;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IProductData _productData;
        private readonly IMapper _mapper;

        public CatalogController(IProductData ProductData, IMapper mapper) 
        {
            _productData = ProductData;
            _mapper = mapper; 
        }

                public IActionResult Index([Bind("BrandId,SectionId")] ProductFilter filter)
        {
            var products = _productData.GetProducts(filter);

            return View(new CatalogViewModel
            {
                BrandId = filter.BrandId,
                SectionId = filter.SectionId,
                Products = products
                   .OrderBy(p => p.Order)
                   .Select(x => _mapper.Map<Product, ProductViewModel>(x)),
            });
        }
    }
}
