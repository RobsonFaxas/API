using MediatR;
using Microsoft.EntityFrameworkCore;
using RRF.Application.UserProfiles.Commands;
using RRF.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRF.Application.UserProfiles.CommandHandlers
{
    public class DeleteUserProfileHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly DataContext _ctx;

        public DeleteUserProfileHandler(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var userProfile = await _ctx.UserProfiles.FirstOrDefaultAsync(up => up.UserProfileId == request.UserProfileId);
            if (userProfile is null)
                return new Unit();
            _ctx.UserProfiles.Remove(userProfile);
            await _ctx.SaveChangesAsync();

            return new Unit();
        }
    }
}
