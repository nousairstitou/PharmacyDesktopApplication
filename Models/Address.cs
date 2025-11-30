using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Models {

    public class Address {

        public int? AddressId { get; set; }

        private string _city;
        public string City {

            get => _city;

            set {

                if(string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(nameof(City) ,"City cannot be null or empty.");

                _city = value;
            }
        }

        private string _street;
        public string Street {

            get => _street;

            set {

                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(nameof(Street),"Street cannot be null or empty.");

                _street = value;
            }
        }

        private int _buildingNumber;
        public int BuildingNumber {

            get => _buildingNumber;

            set {

                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(BuildingNumber) ,"Building Number must be a positive integer.");

                _buildingNumber = value;
            }
        }

        private int? _departmentNumber;
        public int? DepartmentNumber {

            get => _departmentNumber;

            set {

                if (!value.HasValue && value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(DepartmentNumber), "Department Number must be positive if provided.");
                
                _departmentNumber = value;
            }
        }

        private string _zipCode;
        public string ZipCode {

            get => _zipCode;

            set {

                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(nameof(ZipCode), "Zip Code cannot be null or empty.");

                if (!Regex.IsMatch(value, @"^\d{5}(-\d{4})?$"))
                    throw new ArgumentException(nameof(ZipCode), "Zip Code must be 5 digits or in the format 12345-6789.");

                _zipCode = value;
            }
        }
    }   
}