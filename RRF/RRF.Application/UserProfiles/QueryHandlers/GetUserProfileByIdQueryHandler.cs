using MediatR;
using Microsoft.EntityFrameworkCore;
using RRF.Application.UserProfiles.Queries;
using RRF.Dal;
using RRF.Domain.Aggregates.UserProfileAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRF.Application.UserProfiles.QueryHandlers
{
    public class GetUserProfileByIdQueryHandler : IRequestHandler<GetUserProfileById, UserProfile>
    {
        private readonly DataContext _ctx;
        public GetUserProfileByIdQueryHandler(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<UserProfile> Handle(GetUserProfileById request, CancellationToken cancellationToken)
        {
            return await _ctx.UserProfiles.FirstOrDefaultAsync(up => up.UserProfileId == request.UserProfileId);
        }
    }
}
