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
    public static class MockPermissionTypeRepository
    {
        public static void AddDataPermissionTypeRepository(PermissionDbContext permissionDbContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var permissionsTypes = fixture.CreateMany<PermissionType>().ToList();

            permissionsTypes.Add(fixture.Build<PermissionType>().With(x => x.Description, "permiso para hacer test").Create());

            permissionDbContextFake.PermissionType.AddRange(permissionsTypes);
            permissionDbContextFake.SaveChanges();
        }
    }
}
