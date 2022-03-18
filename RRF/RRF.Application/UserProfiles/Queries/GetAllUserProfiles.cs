using MediatR;
using RRF.Application.Models;
using RRF.Domain.Aggregates.UserProfileAggregate;

namespace RRF.Application.UserProfiles.Queries
{
    public class GetAllUserProfiles : IRequest<OperationResult<IEnumerable<UserProfile>>>
    {
    }
}
