using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Permissions.Api.Endpoints.Permissions.Commands;
using Permissions.Api.Utils.Mappings;
using Permissions.Infrastructure.Repositories;
using Permissions.UnitTest.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Permissions.UnitTest.Features.Permission.Commands
{
    public class DeletePermissionXUnitTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;
        private readonly Mock<ILogger<DeletePermission>> _logger;

        public DeletePermissionXUnitTest()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
            _logger = new Mock<ILogger<DeletePermission>>();
            MockPermissionRepository.AddDataPermissionRepository(_unitOfWork.Object.PermissionDbContext);
        }

        [Fact]
        public async Task CreatePermissionCommand()
        {
            var permissionInput = new DeletePermissionRequest
            {
                PermissionId = 1
            };
            var handler = new DeletePermission(_unitOfWork.Object,_logger.Object,_mapper);
            var result = await handler.HandleAsync(permissionInput, CancellationToken.None);
        }
    }
}
