using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace tickethub_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketOrderController : ControllerBase
    {
        private readonly ILogger<TicketOrderController> _logger;
        private readonly IConfiguration _configuration;

        public TicketOrderController(ILogger<TicketOrderController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }


        // GET: api/<TicketOrderController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TicketOrderController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TicketOrderController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        //// PUT api/<TicketOrderController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<TicketOrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
