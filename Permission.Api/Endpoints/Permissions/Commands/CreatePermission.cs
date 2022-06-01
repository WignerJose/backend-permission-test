using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Permissions.Api.Utils;
using Permissions.Core.Domain;
using Permissions.Core.Interfaces;
using Permissions.Core.Interfaces.Elasticsearch;
using Swashbuckle.AspNetCore.Annotations;
using System.Transactions;

namespace Permissions.Api.Endpoints.Permissions.Commands
{
    public class CreatePermission : EndpointBaseAsync.WithRequest<CreatePermissionCommand>.WithActionResult
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IElasticsearchService<Permission> _elasticsearchService;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public CreatePermission(IUnitOfWork unitOfWork, IElasticsearchService<Permission> elasticsearchService, IMapper mapper, ILogger<CreatePermission> logger)
        {
            _unitOfWork = unitOfWork;
            _elasticsearchService = elasticsearchService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost("api/v1/permission", Name = "permissionCreate")]
        [SwaggerOperation(
            Tags = new[] { "Permissions" })]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public override async Task<ActionResult> HandleAsync(CreatePermissionCommand request, CancellationToken cancellationToken = default)
        {
            var permissionType = await _unitOfWork.PermissionTypeRepository.GetByIdAsync(request.PermissionTypeId);
            if (permissionType is null)
                return BadRequest("el parametro del tipo de permiso, no es valido.");

            using var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var permission = _mapper.Map<Permission>(request);
            await _unitOfWork.PermissionRepository.AddAsync(permission);

            var response = await _elasticsearchService.CreatePermissionAsync(permission);
            if (!response.IsValid)
                return BadRequest("Nose pudo registrar la operacion intente mas tarde");
            await _unitOfWork.Complete();
            transaction.Complete();

            var result = _mapper.Map<CreatePermissionResult>(permission);
            return Created("api/permission", result);
        }
    }
}
