using Microsoft.AspNetCore.Mvc;
using RRF.Domain.Aggregates.PostAggregate;

namespace RRF.API.Controllers.V2
{
    [ApiVersion("2.0")]
    [Route(ApiRoutes.BaseRoute)]
    [ApiController]
    public class PostsController : ControllerBase
    {
        [HttpGet]
        [Route(ApiRoutes.Posts.GetByIdRoute)]
        public IActionResult GetById(int id)
        {            
            return Ok();
        }
    }
}
