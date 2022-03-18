using MediatR;
using Microsoft.EntityFrameworkCore;
using RRF.Application.Enums;
using RRF.Application.Exceptions;
using RRF.Application.Models;
using RRF.Application.UserProfiles.Commands;
using RRF.Dal;
using RRF.Domain.Aggregates.UserProfileAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRF.Application.UserProfiles.CommandHandlers
{
    public class DeleteUserProfileHandler : IRequestHandler<DeleteUserCommand, OperationResult<UserProfile>>
    {
        private readonly DataContext _ctx;

        public DeleteUserProfileHandler(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<OperationResult<UserProfile>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<UserProfile>();
            try
            {
                var userProfile = await _ctx.UserProfiles.FirstOrDefaultAsync(up => up.UserProfileId == request.UserProfileId);
                if (userProfile is null)
                {
                    throw new AppException(new Error()
                    {
                        Message = $"No UserProfile was found with ID {request.UserProfileId}.",
                        Code = ErrorCodes.NotFound
                    });
                }

                _ctx.UserProfiles.Remove(userProfile);
                await _ctx.SaveChangesAsync();

                result.Payload = userProfile;
                result.Success = true;
            }
            catch (AppException ex)
            {
                result.Success = false;
                result.Errors.Add(ex.Error);
            }
            catch (Exception ex)
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
