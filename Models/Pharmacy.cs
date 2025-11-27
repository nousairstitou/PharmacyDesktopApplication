using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Models {

    public class Pharmacy {

        public int PharmacyId { get; set; }

        private string _pharmacyName = string.Empty;
        public string PharmacyName {

            get => _pharmacyName;

            set {

                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(nameof(PharmacyName), "Pharmacy name cannot be null or empty.");

                _pharmacyName = value;
            }
        }

        private string _licenseNumber = string.Empty;
        public string LicenseNumber {

            get => _licenseNumber;

            set {

                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(nameof(LicenseNumber), "license Number cannot be null or empty.");

                _licenseNumber = value;
            }
        }

        private string _phone = string.Empty;
        public string? Phone {

            get => _phone;

            set {

                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(nameof(Phone), "Phone cannot be null or empty.");

                if (!Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                    throw new ArgumentException(nameof(Phone), "Invalid phone format.");

                _phone = value;
            }
        }

        private string? _email;
        public string? Email {

           get => _email;

            set {

                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(nameof(Email), "Email cannot be null or empty.");

                if (!Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                    throw new ArgumentException(nameof(Email), "Invalid email format.");

                _email = value;
            }
        }

        private int? _addressId;
        public int? AddressId {

            get => _addressId;

            set {

                if (!value.HasValue || value <= 0)
                    throw new ArgumentException(nameof(AddressId), "AddressId must be a positive integer or null.");

                _addressId = value;
            }
        }

        private int? _managerId;
        public int? ManagerId {

            get => _managerId;

            set {

                if (!value.HasValue || value <= 0)
                    throw new ArgumentException(nameof(ManagerId), "ManagerId must be a positive integer or null.");

                _managerId = value;
            }
        }

        private DateTime _openingDate;
        public DateTime OpeningDate {

            get => _openingDate;

            set {

                if (value > DateTime.Now)
                    throw new ArgumentException(nameof(OpeningDate), "Opening date cannot be in the future.");

                _openingDate = value;
            }
        }

        private bool _isActive;
        public bool IsActive { 

            get => _isActive; 
            set => _isActive = value;
        }

        private DateTime _createdDate;
        public DateTime CreatedDate { get; set; }

        private string? _note;
        public string? Note {

            get => _note;

            set {

                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(nameof(Note), "Note cannot be null or empty.");

                _note = value;
            }
        }

        public Address Address { get; set; }
        public User User { get; set; }
    }
}