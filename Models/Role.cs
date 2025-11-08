using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models {

    public class Role {

        // RolePermissionId is generated automatically by the database
        public int? RoleId { get; private set; }

        private string _roleName = string.Empty;
        public string RoleName {

            get => _roleName;

            set {

                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Role name cannot be null or empty.");

                if (value.Length > 50)
                    throw new ArgumentException("Role name cannot exceed 50 characters.");

                _roleName = value;
            }
        }

        private string? _description;
        public string? Description {

            get => _description;

            set {

                if (value != null && value.Length > 255)
                    throw new ArgumentException("Description cannot exceed 255 characters.");

                _description = value;
            }
        }
    }
}