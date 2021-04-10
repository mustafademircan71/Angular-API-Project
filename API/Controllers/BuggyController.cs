using API.Errors;
using API.Infrastructure.DataContext;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly StoreContext _context;
        public BuggyController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            var product = _context.Products.Find(8);
            if (product==null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok();
        }
        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var product = _context.Products.Find(8);
            var productToReturn = product.ToString();
            return Ok();
        }
        [HttpGet("badRequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }
        [HttpGet("badRequest/{id}")]
        public ActionResult GetNotFoundRequest(int id)
        {
            return BadRequest();
        }
    }
}
