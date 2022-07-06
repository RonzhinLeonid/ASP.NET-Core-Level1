using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ViewModel;
using WebApplication1.Controllers;
using WebStore.Interfaces.Services;
using Assert = Xunit.Assert;

namespace WebApplication.Tests.Controllers
{
    [TestClass]
    public class HomControllerTests
    {
        [TestMethod]
        public void Contacts_returns_with_View()
        {
            var mapper_mock = new Mock<IMapper>();

            var controller = new HomeController(null!, mapper_mock.Object);

            var result = controller.Contacts();

            var view_result = Assert.IsType<ViewResult>(result);

            Assert.Null(view_result.ViewName);
        }

        [TestMethod]
        public void Error404_returns_with_View()
        {
            var mapper_mock = new Mock<IMapper>();

            var controller = new HomeController(null!, mapper_mock.Object);

            var result = controller.Error404();

            var view_result = Assert.IsType<ViewResult>(result);

            Assert.Null(view_result.ViewName);
        }

        private class TestProductData : IProductData
        {
            public IEnumerable<Section> GetSections() { throw new NotImplementedException(); }

            public Section? GetSectionById(int Id) { throw new NotImplementedException(); }

            public IEnumerable<Brand> GetBrands() { throw new NotImplementedException(); }

            public Brand? GetBrandById(int Id) { throw new NotImplementedException(); }

            public IEnumerable<Product> GetProducts(ProductFilter? Filter = null)
            {
                Assert.Null(Filter);
                return Enumerable.Empty<Product>();
            }

            public Product? GetProductById(int Id) { throw new NotImplementedException(); }
        }

        [TestMethod]
        public void Index_returns_with_ViewBag_with_products()
        {
            var mapper_mock = new Mock<IMapper>();
            var products = Enumerable.Range(1, 100).Select(id => new Product { Id = id, Name = $"Product-{id}", Section = new() { Name = "Section" } });
            var controller = new HomeController(null!, mapper_mock.Object);

            var product_data_mock = new Mock<IProductData>();
            product_data_mock.Setup(s => s.GetProducts(It.IsAny<ProductFilter>()))
               .Returns(products);

            var result = controller.Index(product_data_mock.Object);

            var view_result = Assert.IsType<ViewResult>(result);

            var actual_products_result = view_result.ViewData["Products"];

            var actual_products = Assert.IsAssignableFrom<IEnumerable<ProductViewModel>>(actual_products_result);

            Assert.Equal(6, actual_products.Count());
            Assert.Equal(products.Select(p => p.Name).Take(6), actual_products.Select(p => p.Name));
        }
    }
}
