using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permissions.Core.Domain
{
    public class PermissionType
    {
        public int Id { get; set; }
        public String Description { get; set; } = String.Empty;
    }
}
