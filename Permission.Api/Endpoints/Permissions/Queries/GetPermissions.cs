using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Permissions.Core.Domain;
using Permissions.Core.Interfaces;
using Permissions.Core.Interfaces.Elasticsearch;
using Swashbuckle.AspNetCore.Annotations;

namespace Permissions.Api.Endpoints.Permissions.Queries
{
    public class GetPermissions : EndpointBaseAsync.WithoutRequest.WithActionResult<PermissionListResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IElasticsearchService<Permission> _elasticsearchService;

        public GetPermissions(IUnitOfWork unitOfWork, IElasticsearchService<Permission> elasticsearchService, ILogger<GetPermissions> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _elasticsearchService = elasticsearchService;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet("api/v1/permission/all", Name = "GetPermissions")]
        [SwaggerOperation(
            Tags = new[] { "Permissions" })]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        public override async Task<ActionResult<PermissionListResult>> HandleAsync(CancellationToken cancellationToken = default)
        {
            var permissions = await _elasticsearchService.GetPermissionsAsync();
            var result = permissions.Select(permission => _mapper.Map<PermissionListResult>(permission));
            return Ok(result);
        }
    }
}
