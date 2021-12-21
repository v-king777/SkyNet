using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkyNet.Models.Users;

namespace SkyNet.Configs;

public class MessageConfuiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.ToTable("Mesages").HasKey(p => p.Id);
        builder.Property(x => x.Id).UseIdentityColumn();
    }
}