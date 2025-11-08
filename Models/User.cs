using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models {

    public class User {

        // UserId is generated automatically by the database
        public int UserId { get; private set; }

        private int? _personId;
        public int? PersonId {

            get => _personId;

            set {

                if(!value.HasValue || value <= 0)
                    throw new ArgumentException("PersonId must be a positive integer or null.");

                _personId = value;
            }
        }

        private string _userName = string.Empty;
        public string UserName {

            get => _userName;

            set {

                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("UserName cannot be null or empty.");

                _userName = value;
            }
        }

        private string _passwordHash = string.Empty;
        public string PasswordHash {

            get => _passwordHash;

            set {

                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("PasswordHash cannot be null or empty.");

                _passwordHash = value;
            }
        }

        private DateTime _createdDate;
        public DateTime CreatedDate {

            get => _createdDate;

            set {

                if (value > DateTime.Now)
                    throw new ArgumentException("CreatedDate cannot be in the future.");

                _createdDate = value;
            }
        }

        private bool _isActive;
        public bool IsActive {

            get => _isActive;
            set => _isActive = value;
        }

        private int? _roleId;
        public int? RoleId {

            get => _roleId;

            set {

                if (!value.HasValue || value <= 0)
                    throw new ArgumentException("RoleId must be a positive integer or null.");

                _roleId = value;
            }
        }

        public Person Person { get; private set; }
        public Role UserRole { get; set; }
    }
}