using MediatR;
using Microsoft.EntityFrameworkCore;
using RRF.Application.Enums;
using RRF.Application.Exceptions;
using RRF.Application.Models;
using RRF.Application.UserProfiles.Commands;
using RRF.Dal;
using RRF.Domain.Aggregates.UserProfileAggregate;

namespace RRF.Application.UserProfiles.CommandHandlers
{
    public class UpdateUserProfileBasicInfoCommandHandler : IRequestHandler<UpdateUserBasicInfoCommand, OperationResult<UserProfile>>
    {
        private readonly DataContext _ctx;
        public UpdateUserProfileBasicInfoCommandHandler(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<OperationResult<UserProfile>> Handle(UpdateUserBasicInfoCommand request, 
            CancellationToken cancellationToken)
        {
            var result = new OperationResult<UserProfile>();            

            try
            {
                var userProfile = await _ctx.UserProfiles
                .FirstOrDefaultAsync(up => up.UserProfileId == request.UserProfileId);

                if (userProfile is null)
                {
                    throw new AppException(new Error()
                    {
                        Message = $"No UserProfile was found with ID {request.UserProfileId}.",
                        Code = ErrorCodes.NotFound
                    });
                }

                var basicInfo = BasicInfo.CreateBasicInfo(request.FirstName, request.LastName, request.EmailAddress, request.Phone, request.DateOfBirth, request.CurrentCity);
                userProfile.UpdateBasicInfo(basicInfo);
                _ctx.UserProfiles.Update(userProfile);
                await _ctx.SaveChangesAsync();

                result.Payload = userProfile;
                result.Success = true;
            }
            catch (AppException ex)
            {
                result.Success = false;
                result.Errors.Add(ex.Error);
            }
            catch(Exception ex)
            {
                result.Success = false;
                result.Errors.Add(new Error()
                {
                    Message = ex.Message,
                    Code = ErrorCodes.InternalServerError
                });
                if (ex.InnerException is not null)
                {
                    result.Errors.Add(new Error()
                    {
                        Message = ex.InnerException.Message,
                        Code = ErrorCodes.InternalServerError
                    });
                }
            }
            
            return result;
        }
    }
}
