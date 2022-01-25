﻿using AutoMapper;
using MediatR;
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
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserProfile>
    {
        private readonly DataContext _ctx;        
        
        public CreateUserCommandHandler(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<UserProfile> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var basicInfo = BasicInfo.CreateBasicInfo(request.FirstName, request.LastName, request.EmailAddress, request.Phone, request.DateOfBirth, request.CurrentCity);
            var userProfile = UserProfile.CreateUserProfile(Guid.NewGuid().ToString(), basicInfo);
            _ctx.UserProfiles.Add(userProfile);
            await _ctx.SaveChangesAsync();
            return userProfile;
        }
    }
}
