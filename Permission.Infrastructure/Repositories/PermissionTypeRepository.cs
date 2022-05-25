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
    public class PermissionTypeRepository : RepositoryBase<PermissionType>, IPermissionTypeRepository
    {
        public PermissionTypeRepository(PermissionDbContext permissionDbContext) : base(permissionDbContext)
        {
        }
    }
}
