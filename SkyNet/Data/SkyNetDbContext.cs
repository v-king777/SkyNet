using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SkyNet.Models.Users;

namespace SkyNet.Data
{
    public class SkyNetDbContext : IdentityDbContext<User>
    {
        public SkyNetDbContext(DbContextOptions<SkyNetDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
