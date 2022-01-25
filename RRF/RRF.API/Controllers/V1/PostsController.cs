using Microsoft.AspNetCore.Mvc;
using RRF.Domain.Aggregates.PostAggregate;

namespace RRF.API.Controllers.V1
{
    [ApiVersion("1.0")]
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
