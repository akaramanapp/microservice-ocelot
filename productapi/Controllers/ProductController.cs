using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace productapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // GET api/product
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Product 1", "Product 2" };
        }
    }
}
