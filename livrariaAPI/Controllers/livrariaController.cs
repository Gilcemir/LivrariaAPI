using livrariaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace livraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class livrariaController : ControllerBase
    {
        private readonly ToDoContext _context;

        public livrariaController(ToDoContext context)
        {
            _context = context;

            _context.todoProducts.Add(new Product { ID = "1", Name = "book1", Price = 24.0, Quant = 1, Category = "Acao", Img = "Img1" });
            _context.todoProducts.Add(new Product { ID = "2", Name = "book2", Price = 4.0, Quant = 3, Category = "Acao", Img = "Img2" });
            _context.todoProducts.Add(new Product { ID = "3", Name = "book3", Price = 524.0, Quant = 5, Category = "Acao", Img = "Img2" });
            _context.todoProducts.Add(new Product { ID = "4", Name = "book4", Price = 234.0, Quant = 6, Category = "Acao", Img = "Img2" });
            _context.todoProducts.Add(new Product { ID = "5", Name = "book5", Price = 2.0, Quant = 2, Category = "Acao", Img = "Img2" });

            _context.SaveChanges();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.todoProducts.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetItem(int id)
        {
            var item = await _context.todoProducts.FindAsync(id.ToString());

            if (item == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(item);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)    
        {
            _context.todoProducts.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetItem), new { id = product.ID }, product);
        }
    }
}
