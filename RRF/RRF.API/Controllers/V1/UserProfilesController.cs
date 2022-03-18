using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RRF.API.Contracts.Common;
using RRF.API.Contracts.UserProfileContract.Requests;
using RRF.API.Contracts.UserProfileContract.Responses;
using RRF.Application.Enums;
using RRF.Application.UserProfiles.Commands;
using RRF.Application.UserProfiles.Queries;

namespace RRF.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route(ApiRoutes.BaseRoute)]
    [ApiController]
    public class UserProfilesController : BaseController
    {
        private readonly IMediator _mediator;
        private IMapper _mapper;
        public UserProfilesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProfiles()
        {
            var query = new GetAllUserProfiles();
            var response = await _mediator.Send(query);
            var profiles = _mapper.Map<List<UserProfileResponse>>(response.Payload);
            return Ok(profiles);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserProfile([FromBody] UserProfileCreate profile)
        {
            var command = _mapper.Map<CreateUserCommand>(profile);
            var response = await _mediator.Send(command);
            var userProfile = _mapper.Map<UserProfileResponse>(response.Payload);
            return CreatedAtAction(nameof(GetUserProfileById), new { id = userProfile.UserProfileId.ToString() }, userProfile);
        }

        [Route(ApiRoutes.UserProfiles.IdRoute)]
        [HttpGet]
        public async Task<IActionResult> GetUserProfileById(string id)
        {
            var query = new GetUserProfileById { UserProfileId = Guid.Parse(id) };
            var response = await _mediator.Send(query);
            if (!response.Success)
                return HandleErrorResponse(response.Errors);
            var userProfile = _mapper.Map<UserProfileResponse>(response.Payload);
            return Ok(userProfile);
        }

        [HttpPatch]
        [Route(ApiRoutes.UserProfiles.IdRoute)]
        public async Task<IActionResult> UpdateUserProfile(string id, UserProfileUpdate updatedProfile)
        {
            var command = _mapper.Map<UpdateUserBasicInfoCommand>(updatedProfile);
            command.UserProfileId = Guid.Parse(id);
            var response = await _mediator.Send(command);

            if (!response.Success)
                return HandleErrorResponse(response.Errors);

            return Ok(response.Payload);
        }

        [HttpDelete]
        [Route(ApiRoutes.UserProfiles.IdRoute)]
        public async Task<IActionResult> DeleteUserProfile(string id)
        {
            var command = new DeleteUserCommand { UserProfileId = Guid.Parse(id) };
            var response = await _mediator.Send(command);

            if (!response.Success)
                return HandleErrorResponse(response.Errors);

            return Ok(response.Payload);
        }
    }
}
