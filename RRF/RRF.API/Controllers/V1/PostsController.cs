using Microsoft.AspNetCore.Mvc;
using RRF.Domain.Models;

namespace RRF.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var post = new Post { Id = id, Text = "Hello, world!" };
            return Ok(post);
        } 
    }
}
