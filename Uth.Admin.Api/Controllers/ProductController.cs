using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Uth.Admin.Api.Models;
using Uth.Common.Entities;
using Uth.Repository.Abstract;

namespace Uth.Admin.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost("add")]
        public ResponseMessage Add(AddProductModel model)
        {
            var product = CreateProductFromModel(model);

            _productRepository.AddProduct(product);

            return new ResponseMessage()
            {
                IsSuccess = true
            };
        }

        [HttpGet("getAll")]
        public ResponseMessage GetAll()
        {

            var products = _productRepository.GetProducts();

            return new ResponseMessage()
            {
                IsSuccess = true,
                Data = products.OrderBy(p => p.Id)
            };
        }

        [HttpPost("update")]
        public ResponseMessage Update(Product product)
        {
            var result = _productRepository.UpdateProduct(product);
            return new ResponseMessage()
            {
                IsSuccess = result
            };
        }

        [HttpPost("delete")]
        public ResponseMessage Delete([FromBody] int id)
        {
            _productRepository.DeleteProduct(id);
            return new ResponseMessage()
            {
                IsSuccess = true
            };
        }
        [HttpGet("getProduct")]
        public ResponseMessage GetProductById(int id)
        {
            var result = _productRepository.GetProductById(id);
            return new ResponseMessage()
            {
                IsSuccess = true,
                Data = result
            };
        }

        private Product CreateProductFromModel(AddProductModel model)
        {
            var product = new Product()
            {
                Name = model.Name,
                Price = model.Price.Value,
                Type = model.Type.Value,
                ExpirationDate = model.ExpirationDate
            };

            return product;
        }


    }
}

