using ColoursAPITest.Attributes;
using ColoursAPITest.Data;
using ColoursAPITest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ColourAPI.Controllers
{
    //[CustomRoute]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ColourContext _context;
        private readonly ILogger<ValuesController> _logger;

        public ValuesController(
            ColourContext context, 
            ILogger<ValuesController> logger)
        {
            _logger = logger;
            _logger.LogInformation("ctor values");
            _context = context;
        }

        // GET api/values
        [Route("items")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Colour>>> GetColourItems()
        {
            _logger.LogInformation("Get Colour Items3.");

            List<Colour> result = new();

            try
            {
                result = await _context.ColourItems.ToListAsync();

                if (result.Count < 1)
                {
                    _logger.LogInformation("Colours3 collection is empty. Please, add colours to collection.");
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed get colours from db. {ex.Message}, {ex.InnerException}");
                throw new Exception($"Failed get colours from db. {ex.Message}, {ex.InnerException}");
            }

            //return result;
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
