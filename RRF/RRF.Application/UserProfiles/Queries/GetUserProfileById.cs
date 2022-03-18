using MediatR;
using RRF.Application.Models;
using RRF.Domain.Aggregates.UserProfileAggregate;

namespace RRF.Application.UserProfiles.Queries
{
    public class GetUserProfileById : IRequest<OperationResult<UserProfile>>
    {
        public Guid UserProfileId { get; set; }
    }
}
