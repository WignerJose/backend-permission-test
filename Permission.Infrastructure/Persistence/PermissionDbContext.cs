using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Permissions.Core.Domain;
using Permissions.Infrastructure.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permissions.Infrastructure.Persistence
{
    public class PermissionDbContext : DbContext
    {
        private readonly string _connectionString;

        public PermissionDbContext(IOptions<DataBaseConfig> dataBaseConfig)
        {
            _connectionString = dataBaseConfig.Value.ConnectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public DbSet<Permission> Permission { get; set; }

    }
}
