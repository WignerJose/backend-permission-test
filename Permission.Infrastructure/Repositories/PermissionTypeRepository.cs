using Permissions.Core.Domain;
using Permissions.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permissions.Infrastructure.Repositories
{
    public class PermissionTypeRepository : IPermissionTypeRepository
    {
        public Task AddAsync(PermissionType permissionType)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(PermissionType permissionType)
        {
            throw new NotImplementedException();
        }

        public Task<List<PermissionType>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PermissionType> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(PermissionType permissionType)
        {
            throw new NotImplementedException();
        }
    }
}
