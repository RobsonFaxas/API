using AutoMapper;
using MediatR;
using RRF.Application.Enums;
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
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, OperationResult<UserProfile>>
    {
        private readonly DataContext _ctx;        
        
        public CreateUserCommandHandler(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<OperationResult<UserProfile>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<UserProfile>();
            try
            {
                var basicInfo = BasicInfo.CreateBasicInfo(request.FirstName, request.LastName, request.EmailAddress, request.Phone, request.DateOfBirth, request.CurrentCity);
                var userProfile = UserProfile.CreateUserProfile(Guid.NewGuid().ToString(), basicInfo);
                _ctx.UserProfiles.Add(userProfile);
                await _ctx.SaveChangesAsync();

                result.Payload = userProfile;
                result.Success = true;
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
