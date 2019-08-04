using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using static customerapi.Startup;

namespace customerapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IUserApiClient _api;

        private readonly IConfiguration _config;

        private readonly FetcherOptions _opt;

        public CustomerController(IConfiguration configuration, IOptions<FetcherOptions> opt)
        {
            //this._api = api;
            this._config = configuration;

            this._opt = opt.Value;

        }
        // GET api/Customer
        //[Authorize]
        [HttpGet]
        public  FetcherOptions GetAsync()
        {
            return _opt;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
