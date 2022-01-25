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
    public class GetAllUserProfilesQueryHandler : IRequestHandler<GetAllUserProfiles, IEnumerable<UserProfile>>
    {
        private readonly DataContext _ctx;

        public GetAllUserProfilesQueryHandler(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<IEnumerable<UserProfile>> Handle(GetAllUserProfiles request, 
            CancellationToken cancellationToken)
        {
            return await _ctx.UserProfiles.ToListAsync();
        }
    }
}
