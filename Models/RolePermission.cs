using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models{

    public class RolePermission {

        // RolePermissionId is generated automatically by the database
        public int? RolePermissionId { get; private set; }
        public int RoleId { get; private set; }
        public int PermissionId { get; private set; }

        public Role role { get; set; }
        public Permission permission { get; set; }
    }
}