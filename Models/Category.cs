using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models {

    public class Category {

        // CategoryId is generated automatically by the database
        public int? CategoryId { get; set; }

        private string _categoryName = string.Empty;
        public string CategoryName {

            get => _categoryName;

            set {

                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Category name cannot be null or empty.");

                if(value.Length > 50)
                    throw new ArgumentException("Category name cannot exceed 50 characters.");

                _categoryName = value;
            }
        }

        public bool IsActive { get; set; }
        public DateTime DeactivatedAt { get; set; }

        private DateTime _createdDate;
        public DateTime CreatedDate { 

            get => _createdDate;

            set {

                if (value > DateTime.Now)
                    throw new ArgumentException("CreatedDate cannot be in the future.");

                _createdDate = value;
            }
        }

        private int? _createdBy;
        public int? CreatedBy {

            get => _createdBy;

            set {

                if (!value.HasValue || value <= 0)
                    throw new ArgumentException("CreatedBy must be a positive integer or null.");

                _createdBy = value;
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