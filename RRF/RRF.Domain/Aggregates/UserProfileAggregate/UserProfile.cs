using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRF.Domain.Aggregates.UserProfileAggregate
{
    public class UserProfile
    {
        private UserProfile()
        {
        }

        public Guid UserProfileId { get; private set; }
        public string IdentityId { get; private set; }
        public BasicInfo BasicInfo { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime LastModifiedAt { get; private set; }

        // Factory Method
        public static UserProfile CreateUserProfile(string identityId, BasicInfo basicInfo)
        {
            // TO DO: add validation, error handling strategies, error notification strategies
            return new UserProfile
            {
                IdentityId = identityId,
                BasicInfo = basicInfo,
                CreatedAt = DateTime.UtcNow,
                LastModifiedAt = DateTime.UtcNow
            };            
        }

        // Public methods
        public void UpdateBasicInfo(BasicInfo newInfo)
        {
            BasicInfo = newInfo;
            LastModifiedAt = DateTime.UtcNow;
        }
    }
}
