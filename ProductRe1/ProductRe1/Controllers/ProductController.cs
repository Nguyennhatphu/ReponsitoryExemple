using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DemoRepository.Models;
using DemoRepository.Services.Interfaces;

namespace DemoRepository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: api/Product
        [HttpGet]
        public async Task<IActionResult> ListProduct()
        {
            var product = await _productService.ListProduct();
            return StatusCode(200, product);
        }

        [HttpGet] //api/Product/id
        [Route("{id}")]

        public async Task<IActionResult> GetProduct(int? id)
        {
            var product = await _productService.GetProduct(id);
            return StatusCode(200, product);
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            await _productService.AddProduct(product);
            return StatusCode(200, product);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> EditProduct(int id,Product product)
        {
            await _productService.EditProduct(id,product);
            return StatusCode(200, product);
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteProduct(int? id)
        {
            var product = await _productService.DeleteProduct(id);
            return StatusCode(200, product);
        }
    }
}