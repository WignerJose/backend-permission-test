using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Permissions.Api.Endpoints.Permissions.Commands;
using Permissions.Api.Utils.Mappings;
using Permissions.Infrastructure.Repositories;
using Permissions.UnitTest.Mocks;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Permissions.UnitTest.Features.Permission.Commands
{
    public class CreatePermissionXUniTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;
        private readonly Mock<ILogger<CreatePermission>> _logger;

        public CreatePermissionXUniTest()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
            _logger = new Mock<ILogger<CreatePermission>>();
            MockPermissionRepository.AddDataPermissionRepository(_unitOfWork.Object.PermissionDbContext);
        }
        [Fact]
        public async Task CreatePermissionCommand()
        {
            var permissionInput = new CreatePermissionCommand
            {
                EmployeeLastName = "Cruz",
                EmployeeName = "wigner",
                PermissionTypeId = 1
            };
            var handler = new Create(_unitOfWork.Object, _mapper, _logger.Object);
            var result = await handler.HandleAsync(permissionInput,CancellationToken.None);
        }
    }
}
