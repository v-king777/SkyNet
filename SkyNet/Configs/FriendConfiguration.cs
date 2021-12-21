using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkyNet.Models.Users;

namespace SkyNet.Configs;

public class FriendConfiguration : IEntityTypeConfiguration<Friend>
{

    public void Configure(EntityTypeBuilder<Friend> builder)
    {
        builder.ToTable("UserFriends").HasKey(p => p.Id);
        builder.Property(x => x.Id).UseIdentityColumn();
    }
}