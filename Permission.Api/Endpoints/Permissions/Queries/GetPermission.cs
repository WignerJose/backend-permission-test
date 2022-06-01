using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Permissions.Core.Domain;
using Permissions.Core.Interfaces;
using Permissions.Core.Interfaces.Elasticsearch;
using Swashbuckle.AspNetCore.Annotations;

namespace Permissions.Api.Endpoints.Permissions.Queries
{
    public class GetPermission : EndpointBaseAsync.WithRequest<int>.WithActionResult<GetPermissionResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public GetPermission(IUnitOfWork unitOfWork, ILogger<GetPermission> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet("api/v1/permission/{permissionId}", Name = "GetPermission")]
        [SwaggerOperation(
            Tags = new[] { "Permissions" })]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public override async Task<ActionResult<GetPermissionResult>> HandleAsync(int permissionId, CancellationToken cancellationToken = default)
        {
            var permission = await _unitOfWork.PermissionRepository.GetByIdAsync(permissionId);
            if (permission is null)
                return NotFound("No se puedo encontrar el permiso que buscaba");
            var result = _mapper.Map<GetPermissionResult>(permission);
            return Ok(result);
        }
    }
}
