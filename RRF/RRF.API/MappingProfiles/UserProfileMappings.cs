using AutoMapper;
using RRF.API.Contracts.UserProfileContract.Requests;
using RRF.API.Contracts.UserProfileContract.Responses;
using RRF.Application.UserProfiles.Commands;
using RRF.Domain.Aggregates.UserProfileAggregate;

namespace RRF.API.MappingProfiles
{
    public class UserProfileMappings : Profile
    {
        public UserProfileMappings()
        {
            CreateMap<UserProfileCreate, CreateUserCommand>();
            CreateMap<UserProfileUpdate, UpdateUserBasicInfoCommand>();
            CreateMap<UserProfile, UserProfileResponse>();
            CreateMap<BasicInfo, BasicInfoResponse>();
        }
    }
}
