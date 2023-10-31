using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Context
{
    public class CastoryDbContext : DbContext
    {
        public CastoryDbContext(DbContextOptions<CastoryDbContext> options) : base(options)
        {
        }



        public DbSet<Castory> Castories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Follower> Followers { get; set; }

        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

    }
}
