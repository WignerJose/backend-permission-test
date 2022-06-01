using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Permissions.Core.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace Permissions.Api.Endpoints.PermissionTypes.Queries
{
    public class PermissionTypeList : EndpointBaseAsync.WithoutRequest.WithActionResult<PermissionTypeListResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public PermissionTypeList(IUnitOfWork unitOfWork, ILogger<PermissionTypeList> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("api/v1/permission-type/all", Name = "GetPermissionTypes")]
        [SwaggerOperation(
            Tags = new[] { "PermissionTypes" })]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        public async override Task<ActionResult<PermissionTypeListResult>> HandleAsync(CancellationToken cancellationToken = default)
        {
            var permissionTypes = await _unitOfWork.PermissionTypeRepository.GetAllAsync();
            var result = permissionTypes.Select(permissionType => _mapper.Map<PermissionTypeListResult>(permissionType));
            return Ok(result);
        }
    }
}
