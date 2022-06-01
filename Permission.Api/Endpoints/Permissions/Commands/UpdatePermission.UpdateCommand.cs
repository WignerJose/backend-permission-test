using Microsoft.AspNetCore.Mvc;

namespace Permissions.Api.Endpoints.Permissions.Commands
{
    public class UpdatePermissionCommand
    {
        [FromRoute(Name = "PermissionId")]
        public int PermissionId { get; set; }
        [FromBody]
        public UpdatePermissionRequest UpdateRequest { get; set; }
    }

    public class UpdatePermissionRequest
    {
        public String EmployeeName { get; set; } = String.Empty;
        public String EmployeeLastName { get; set; } = String.Empty;
        public int PermissionTypeId { get; set; }
    }
}
