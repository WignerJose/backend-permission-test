using Microsoft.EntityFrameworkCore;
using Moq;
using Permissions.Infrastructure.Persistence;
using Permissions.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permissions.UnitTest.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<UnitOfWork> GetUnitOfWork()
        {
            var options = new DbContextOptionsBuilder<PermissionDbContext>()
                              .UseInMemoryDatabase(databaseName: $"PermissionDbContext-{Guid.NewGuid()}")
                              .Options;

            var permissionDbContextFake = new PermissionDbContext(options);
            permissionDbContextFake.Database.EnsureDeleted();
            var mockUnitOfWork = new Mock<UnitOfWork>(permissionDbContextFake);
            return mockUnitOfWork;
        }
    }
}
