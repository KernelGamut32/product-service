using BusinessServices.Interfaces;
using DataServices.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await productService.RetrieveAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await productService.RetrieveById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Product product)
        {
            await productService.Create(product);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Product product)
        {
            await productService.Update(product);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await productService.Delete(id);
            return Ok();
        }
    }
}
