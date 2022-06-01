using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Permissions.Api.Endpoints.Permissions.Commands;
using Permissions.Api.Utils.Mappings;
using Permissions.Infrastructure.Repositories;
using Permissions.UnitTest.Mocks;

namespace Permissions.UnitTest.Features.Permission.Commands
{
    public class UpdatePermissionXUnitTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;
        private readonly Mock<ILogger<UpdatePermission>> _logger;

        public UpdatePermissionXUnitTest()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
            _logger = new Mock<ILogger<UpdatePermission>>();
            MockPermissionRepository.AddDataPermissionRepository(_unitOfWork.Object.PermissionDbContext);
        }
        public async Task CreatePermissionCommand()
        {
            var updateRequest = new UpdatePermissionRequest
            {
                EmployeeLastName = "Wigner",
                EmployeeName = "jose",
                PermissionTypeId = 1
            };
            var permissionInput = new UpdatePermissionCommand
            {
                PermissionId = 1,
                UpdateRequest = updateRequest
            };
            var handler = new UpdatePermission(_unitOfWork.Object,_logger.Object, _mapper);
            var result = await handler.HandleAsync(permissionInput, CancellationToken.None);
        }
    }
}
