using Permissions.Core.Interfaces;
using Permissions.Infrastructure.Persistence;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permissions.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private Hashtable _repositories;
        private readonly PermissionDbContext _permissionDbContext;
        private readonly IPermissionRepository _permissionRepository;
        private readonly IPermissionTypeRepository _permissionTypeRepository;

        public UnitOfWork(PermissionDbContext permissionDbContext)
        {
            _permissionDbContext = permissionDbContext;
        }

        public IPermissionRepository PermissionRepository => throw new NotImplementedException();

        public IPermissionTypeRepository PermissionTypeRepository => throw new NotImplementedException();

        public async Task<int> Complete()
        {
            return await _permissionDbContext.SaveChangesAsync();
        }

        public IRepositoryAsync<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (_repositories is null)
            {
                _repositories = new Hashtable();
            }

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(RepositoryBase<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                _repositories.Add(type, repositoryInstance);
            }

            return (IRepositoryAsync<TEntity>)_repositories[type];
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
