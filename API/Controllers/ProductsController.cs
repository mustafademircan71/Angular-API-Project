using API.Data.DataContext;
using API.Data.DbModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _ctx;

        public ProductsController(StoreContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var data = await _ctx.Products.ToListAsync();
            return data;
        }
        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            return _ctx.Products.Find(id);
            
        }
    }
}
