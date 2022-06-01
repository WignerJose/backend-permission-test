using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Permissions.Core.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace Permissions.Api.Endpoints.Permissions.Commands
{
    public class DeletePermission : EndpointBaseAsync.WithRequest<DeletePermissionRequest>.WithActionResult
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public DeletePermission(IUnitOfWork unitOfWork, ILogger<DeletePermission> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpDelete("api/v1/permission/{PermissionId}", Name = "DeletePermission")]
        [SwaggerOperation(
            Tags = new[] { "Permissions" })]
        [Produces("application/json")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public override async Task<ActionResult> HandleAsync([FromRoute] DeletePermissionRequest request, CancellationToken cancellationToken = default)
        {
            var permission = await _unitOfWork.PermissionRepository.GetByIdAsync(request.PermissionId);
            if (permission is null)
                return NotFound("No existe el permiso que desea eliminar");
            await _unitOfWork.PermissionRepository.DeleteAsync(permission);
            await _unitOfWork.Complete();
            return NoContent();
        }
    }
}
