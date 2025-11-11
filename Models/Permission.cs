using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models {

    public class Permission {

        // RolePermissionId is generated automatically by the database
        public int? PermissionId { get; set; }

        private string _permissionName = string.Empty;
        public string PermissionName {

            get => _permissionName;

            set {

                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Permission name cannot be null or empty.");

                if (value.Length > 50)
                    throw new ArgumentException("Permission name cannot exceed 50 characters.");

                _permissionName = value;
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