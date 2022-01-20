using Microsoft.AspNetCore.Mvc;
using RRF.Domain.Aggregates.PostAggregate;

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
            return Ok();
        } 
    }
}
