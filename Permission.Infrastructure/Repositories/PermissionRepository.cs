using Permissions.Core.Domain;
using Permissions.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permissions.Infrastructure.Repositories
{
    public class PermissionRepository : IPermissionRepository
    {
        public Task AddAsync(Permission permission)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Permission permission)
        {
            throw new NotImplementedException();
        }

        public Task<List<Permission>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Permission> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Permission permission)
        {
            throw new NotImplementedException();
        }
    }
}
