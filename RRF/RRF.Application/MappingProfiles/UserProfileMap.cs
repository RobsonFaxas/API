using AutoMapper;
using RRF.Application.UserProfiles.Commands;
using RRF.Domain.Aggregates.UserProfileAggregate;

namespace RRF.Application.MappingProfiles
{
    internal class UserProfileMap : Profile
    {
        public UserProfileMap()
        {
            CreateMap<CreateUserCommand,BasicInfo>();            
        }
    }
}
