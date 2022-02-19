using Microsoft.AspNetCore.Mvc;
using RRF.API.Contracts.Common;
using RRF.Application.Enums;
using RRF.Application.Models;

namespace RRF.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route(ApiRoutes.BaseRoute)]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IActionResult HandleErrorResponse(List<Error> errors)
        {
            ErrorResponse apiError;
            if (errors.Any(e => e.Code == ErrorCodes.NotFound))
            {
                var error = errors.FirstOrDefault(e => e.Code == ErrorCodes.NotFound);
                apiError = new ErrorResponse()
                {
                    StatusCode = (int)ErrorCodes.NotFound,
                    StatusPhrase = "Not Found",
                    Timestamp = DateTime.Now
                };
                apiError.Errors.Add(error?.Message ?? "");

                return NotFound(apiError);
            }

            if (errors.Any(e => e.Code == ErrorCodes.InternalServerError))
            {
                var error = errors.FirstOrDefault(e => e.Code == ErrorCodes.InternalServerError);
                apiError = new ErrorResponse()
                {
                    StatusCode = (int)ErrorCodes.InternalServerError,
                    StatusPhrase = "Internal Server Error",
                    Timestamp = DateTime.Now
                };
                apiError.Errors.Add(error?.Message ?? "");
                return StatusCode((int)ErrorCodes.InternalServerError, apiError);
            }

            // default path
            apiError = new ErrorResponse()
            {
                StatusCode = (int)ErrorCodes.InternalServerError,
                StatusPhrase = "Internal Server Error",
                Timestamp = DateTime.Now                
            };
            apiError.Errors.Add("Unknown error");
            apiError.Errors.Add(errors?.FirstOrDefault()?.Message ?? "Exception message not found");
            return StatusCode(500, apiError);
        }
    }
}
