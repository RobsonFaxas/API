using MediatR;
using RRF.Domain.Aggregates.UserProfileAggregate;

namespace RRF.Application.UserProfiles.Queries
{
    public class GetAllUserProfiles : IRequest<IEnumerable<UserProfile>>
    {
    }
}
