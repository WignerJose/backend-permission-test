using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permission.Core.Domain
{
    public class Permission
    {
        public int Id { get; set; }
        public String EmployeeName { get; set; } = String.Empty;
        public String EmployeeLastName { get; set; } = String.Empty;
        public PermissionType PermissionType { get; set; } = new PermissionType();
        public DateTime PermissionDate { get; set; } 
    }
}
