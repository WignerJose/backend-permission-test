using Permissions.Core.Domain;
using Permissions.Core.Interfaces;
using Permissions.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permissions.Infrastructure.Repositories
{
    public class PermissionRepository : RepositoryBase<Permission>, IPermissionRepository
    {
        public PermissionRepository(PermissionDbContext permissionDbContext) : base(permissionDbContext)
        {
        }
    }
}
