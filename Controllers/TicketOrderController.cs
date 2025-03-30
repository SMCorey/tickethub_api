using Azure.Storage.Queues;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices.Marshalling;
using System.Text.Json;
using tickethub_api.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace tickethub_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketOrderController : ControllerBase
    {
        private readonly ILogger<TicketOrderController> _logger;
        private readonly IConfiguration _configuration;
        QueueClient queueClient;
        string queueName = "tickethub";
        string connectionString;

        public TicketOrderController(ILogger<TicketOrderController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("AzureStorage");
            queueClient = new QueueClient(connectionString, queueName);
            queueClient.CreateIfNotExistsAsync();
        }

        //GET: api/<TicketOrderController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //GET api/<TicketOrderController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<TicketOrderController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TicketOrder ticketOrder)
        {
            try
            {
                string messageJson = JsonSerializer.Serialize(ticketOrder);

                await queueClient.SendMessageAsync(messageJson);

                return Ok("Order has been placed");

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);



            }

            //// PUT api/<TicketOrderController>/5
            //[HttpPut("{id}")]
            //public void Put(int id, [FromBody] string value)
            //{
            //}

            // DELETE api/<TicketOrderController>/5
            //[HttpDelete("{id}")]
            //public void Delete(int id)
            //{
            //}
        }
    }
}
