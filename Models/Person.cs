using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Models {

    public class Person {

        // PersonId is generated automatically by the database
        public int? PersonId { get; set; }

        private string _name = null!;
        public string Name {

            get => _name;

            set {

                if (string.IsNullOrWhiteSpace(_name))
                    throw new ArgumentException(nameof(Name), "Name cannot be null or empty.");

                _name = value;
            }
        }

        private string _phone;
        public string Phone {

            get => _phone;

            set {

                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(nameof(Phone), "Phone cannot be null or empty.");

                if(value.Length > 15 || value.Length < 10)
                    throw new ArgumentException(nameof(Phone), "Phone number must be between 10 and 15 characters long.");

                if (!Regex.IsMatch(value, @"^\+?[1-9]\d{1,14}$"))
                    throw new ArgumentException(nameof(Phone), "Invalid phone number format.");

                _phone = value;
            }
        }

        private string? _email;
        public string? Email {

            get => _email;

            set {

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
                    throw new ArgumentOutOfRangeException(nameof(AddressId), "Address ID must be a positive integer.");

                _addressId = value;
            }
        }

        public Address? PersonAddress { get; set; }
    }
}