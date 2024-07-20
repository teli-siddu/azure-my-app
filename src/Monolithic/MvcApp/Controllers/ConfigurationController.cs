using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MvcApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        public IConfiguration Configuration { get; }

        public ConfigurationController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // GET: api/<ConfigurationController>
        [HttpGet]
        public Dictionary<string,string> Get()
        {
            return Configuration.GetSection("Demo")
                .GetChildren()
                .ToDictionary(x=>x.Key,y=>y.Value)!;
        }

        // GET api/<ConfigurationController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ConfigurationController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ConfigurationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ConfigurationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
