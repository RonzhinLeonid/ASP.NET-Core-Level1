﻿using AutoMapper;
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
                   .Select(x => _mapper.Map<ProductViewModel>(x)),
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
