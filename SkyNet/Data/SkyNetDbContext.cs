using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SkyNet.Configs;
using SkyNet.Models.Users;

namespace SkyNet.Data
{
    public class SkyNetDbContext : IdentityDbContext<User>
    {
        public SkyNetDbContext(DbContextOptions<SkyNetDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new FriendConfiguration());
            builder.ApplyConfiguration(new MessageConfuiguration());
        }
    }
}
