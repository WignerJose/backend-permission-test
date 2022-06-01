
namespace Permissions.Core.Domain
{
    public class Permission
    {
        public int Id { get; set; }
        public String EmployeeName { get; set; } = String.Empty;
        public String EmployeeLastName { get; set; } = String.Empty;
        public DateTime PermissionDate { get; set; } 
        public int PermissionTypeId { get; set; }
        public virtual PermissionType PermissionType { get; set; }

        public Permission()
        {
            this.PermissionDate = DateTime.Now;
        }
    }
}
