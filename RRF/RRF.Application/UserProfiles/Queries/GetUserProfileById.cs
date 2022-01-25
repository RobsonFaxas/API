using MediatR;
using RRF.Domain.Aggregates.UserProfileAggregate;

namespace RRF.Application.UserProfiles.Queries
{
    public class GetUserProfileById : IRequest<UserProfile>
    {
        public Guid UserProfileId { get; set; }
    }
}
