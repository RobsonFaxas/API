using MediatR;
using Microsoft.EntityFrameworkCore;
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
    public class UpdateUserProfileBasicInfoCommandHandler : IRequestHandler<UpdateUserBasicInfoCommand>
    {
        private readonly DataContext _ctx;
        public UpdateUserProfileBasicInfoCommandHandler(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<Unit> Handle(UpdateUserBasicInfoCommand request, 
            CancellationToken cancellationToken)
        {
            var userProfile = await _ctx.UserProfiles
                .FirstOrDefaultAsync(up => up.UserProfileId == request.UserProfileId);
            var basicInfo = BasicInfo.CreateBasicInfo(request.FirstName, request.LastName, request.EmailAddress, request.Phone, request.DateOfBirth, request.CurrentCity);
            userProfile.UpdateBasicInfo(basicInfo);
            _ctx.UserProfiles.Update(userProfile);
            await _ctx.SaveChangesAsync();
            return new Unit();
        }
    }
}
