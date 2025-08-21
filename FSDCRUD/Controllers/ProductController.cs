using FSDCRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FSDCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductDbContext _context;
        public ProductController(ProductDbContext context) {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
                if (product == null)
                    return NotFound();

                return Ok(product);     
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Product inserted" });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(Product product, int id)
        {
            var editproduct = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (editproduct == null)
                return NotFound();
            editproduct.Name = product.Name;
            editproduct.Price = product.Price;

            await _context.SaveChangesAsync();
            return Ok(new { message = "Product updated" });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var delproduct = await _context.Products.FirstOrDefaultAsync(y => y.Id == id);
            if (delproduct == null)
                return NotFound();
            _context.Products.Remove(delproduct);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Delete product" });
        }
    }
}
