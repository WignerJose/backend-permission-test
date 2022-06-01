namespace Permissions.Api.Endpoints.Permissions.Queries
{
    public class GetPermissionResult
    {
        public String EmployeeName { get; set; } = String.Empty;
        public String EmployeeLastName { get; set; } = String.Empty;
        public DateTime PermissionDate { get; set; }
        public int PermissionTypeId { get; set; }
    }
}
