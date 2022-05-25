using Permissions.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permissions.Core.Interfaces
{
    public interface IPermissionTypeRepository
    {
        Task<List<PermissionType>> GetAllAsync();
        Task<PermissionType> GetByIdAsync(int id);
        Task AddAsync(PermissionType permissionType);
        Task UpdateAsync(PermissionType permissionType);
        Task DeleteAsync(PermissionType permissionType);
    }
}
