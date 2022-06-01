using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Permissions.Core.Domain;
using Permissions.Core.Interfaces;
using Permissions.Core.Interfaces.Elasticsearch;
using Swashbuckle.AspNetCore.Annotations;
using System.Transactions;

namespace Permissions.Api.Endpoints.Permissions.Commands
{
    public class UpdatePermission : EndpointBaseAsync.WithRequest<UpdatePermissionCommand>.WithActionResult
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IElasticsearchService<Permission> _elasticsearchService;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public UpdatePermission(IUnitOfWork unitOfWork, IElasticsearchService<Permission> elasticsearchService, ILogger<UpdatePermission> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _elasticsearchService = elasticsearchService;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpPut("api/v1/permission/{PermissionId}", Name = "updatePermission")]
        [SwaggerOperation(
            Tags = new[] { "Permissions" })]
        [Produces("application/json")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public override async Task<ActionResult> HandleAsync([FromRoute] UpdatePermissionCommand request, CancellationToken cancellationToken = default)
        {

            var permission = await _unitOfWork.PermissionRepository.GetByIdAsync(request.PermissionId);
            if (permission is null)
                return NotFound("La cuenta que desea actualizar, tiene errores");

            var permissionType = await _unitOfWork.PermissionTypeRepository.GetByIdAsync(request.UpdateRequest.PermissionTypeId);
            if (permissionType is null)
                return BadRequest("el parametro del tipo de permiso, no es valido.");

            using var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            _mapper.Map(request.UpdateRequest,permission);
            await _unitOfWork.PermissionRepository.UpdateAsync(permission);
            await _unitOfWork.Complete();
            var response = await _elasticsearchService.UpdatePermissionAsync(permission);
            if (!response.IsValid)
                return BadRequest("Nose se puede realizar la modificacion, intentelo mas tarde");
            transaction.Complete();

            return NoContent();
        }
    }
}
