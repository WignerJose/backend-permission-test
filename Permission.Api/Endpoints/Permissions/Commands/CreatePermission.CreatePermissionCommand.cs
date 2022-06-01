namespace Permissions.Api.Endpoints.Permissions.Commands
{
    public class CreatePermissionCommand
    {
        public String EmployeeName { get; set; } = String.Empty;
        public String EmployeeLastName { get; set; } = String.Empty;
        public int PermissionTypeId { get; set; }
    }
}
