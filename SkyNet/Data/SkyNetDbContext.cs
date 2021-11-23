using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SkyNet.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
