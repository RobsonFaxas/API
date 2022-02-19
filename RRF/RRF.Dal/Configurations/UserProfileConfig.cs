using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RRF.Domain.Aggregates.UserProfileAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRF.Dal.Configurations
{
    internal class UserProfileConfig : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.OwnsOne(up => up.BasicInfo).Property(p => p.Phone).HasMaxLength(30);
            builder.OwnsOne(up => up.BasicInfo).Property(p => p.EmailAddress).HasMaxLength(200);
            builder.OwnsOne(up => up.BasicInfo).Property(p => p.CurrentCity).HasMaxLength(100);
            builder.OwnsOne(up => up.BasicInfo).Property(p => p.FirstName).HasMaxLength(100);
            builder.OwnsOne(up => up.BasicInfo).Property(p => p.LastName).HasMaxLength(100);
        }
    }
}
