using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyFirstMVCApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyDataApiController : ControllerBase
    {
        
        // GET: api/MyDataApi
        [HttpGet]
        public IActionResult Get()
        {
            var data = new[]
            {
                new { Name = "John Doe", Age = 30 },
                new { Name = "Jane Smith", Age = 25 },
                new { Name = "Bob Johnson", Age = 35 },
                new { Name = "Alice Brown", Age = 28 }
            };

            return Ok(data);
        }

        // GET: api/MyDataApi/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = new { Id = id, Name = "John Doe", Age = 30 };
            return Ok(data);
        }
        
    }
}
