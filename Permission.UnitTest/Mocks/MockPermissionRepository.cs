using AutoFixture;
using Permissions.Core.Domain;
using Permissions.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permissions.UnitTest.Mocks
{
    public static class MockPermissionRepository
    {
        public static void AddDataPermissionRepository(PermissionDbContext permissionDbContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var permissions = fixture.CreateMany<Permission>().ToList();

            permissions.Add(fixture.Build<Permission>().With(x => x.EmployeeName, "wigner").Create());

            permissionDbContextFake.Permission.AddRange(permissions);
            permissionDbContextFake.SaveChanges();
        }
    }
}
