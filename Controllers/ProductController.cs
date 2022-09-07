using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Produvtapi.Models;

namespace Produvtapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductContext db;
        public ProductController(ProductContext _db)
        {
            db = _db;
        }
        [HttpGet]
        public async Task <ActionResult<List<Product>>> GetProducts()
        {
            return Ok(await db.Products.ToListAsync());
        }
        [HttpGet]
        [Route("Get")]
        public async Task< ActionResult<Product>> Get(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Product p =await db.Products.FindAsync(id);
            if(p== null)
            {
                return NotFound();
            }
            return Ok(p);
        }
        [HttpPost]
        public async Task< ActionResult> Add(Product P)
        {
            db.Products.Add(P);
            await db.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task< ActionResult> Edit(int id, [FromBody] Product p)
        {
            db.Products.Update(p);
            await db.SaveChangesAsync();
            return Ok();

        }
        [HttpDelete]
        public async Task< ActionResult> Remove(int id)
        {
            Product p = db.Products.Find(id);
            db.Products.Remove(p);
            await db.SaveChangesAsync();
            return Ok();
        }
       
    }
}
