using AutoMapper;
using Permissions.Api.Endpoints.Permissions.Commands;
using Permissions.Api.Endpoints.Permissions.Queries;
using Permissions.Api.Endpoints.PermissionTypes.Queries;
using Permissions.Core.Domain;

namespace Permissions.Api.Utils.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreatePermissionCommand, Permission>();
            CreateMap<UpdatePermissionRequest, Permission>();
            CreateMap<Permission, GetPermissionResult>();
            CreateMap<Permission, PermissionListResult>();
            CreateMap<Permission, CreatePermissionResult>();
            CreateMap<PermissionType, PermissionTypeListResult>();
        }
    }
}
