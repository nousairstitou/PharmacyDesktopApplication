using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models {

    public class Medicine {

        // MedicineId is generated automatically by the database
        public int MedicineId { get; set; }

        private string _medicineName = string.Empty;
        public string MedicineName {

            get => _medicineName;

            set { 
            
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Medicine name cannot be empty.");

                _medicineName = value;
            }
        }

        private string _scientificName = string.Empty;
        public string ScientificName {

            get => _scientificName;

            set { 
            
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Scientific name cannot be empty.");

                _scientificName = value;
            }
        }

        private int? _categoryId;
        public int? CategoryId {

            get => _categoryId;

            set { 
            
                if (!value.HasValue || value <= 0)
                    throw new ArgumentException("Category ID must be a positive integer or null.");

                _categoryId = value;
            }
        }

        private int? _supplierId;
        public int? SupplierId {

            get => _supplierId;

            set { 
            
                if (!value.HasValue || value <= 0)
                    throw new ArgumentException("Supplier ID must be a positive integer or null.");

                _supplierId = value;
            }
        }

        private int? _inventoryId;
        public int? InventoryId {

            get => _inventoryId;

            set { 
            
                if (value <= 0)
                    throw new ArgumentException("Inventory ID must be a positive integer or null");

                _inventoryId = value;
            }
        }

        private decimal _price;
        public decimal Price {

            get => _price;

            set { 
            
                if (value < 0)
                    throw new ArgumentException("Price cannot be negative.");

                _price = value;
            }
        }

        private int _quantityInStock;
        public int QuantityInStock {

            get => _quantityInStock;

            set { 
            
                if (value < 0)
                    throw new ArgumentException("Quantity in stock cannot be negative.");

                _quantityInStock = value;
            }
        }

        private DateTime _manufactureDate;
        public DateTime ManufactureDate {

            get => _manufactureDate;

            set { 
            
                if (value > DateTime.Now)
                    throw new ArgumentException("Manufacture date cannot be in the future.");

                _manufactureDate = value;
            }
        }

        private DateTime _expiryDate;
        public DateTime ExpiryDate {

            get => _expiryDate;

            set {

                if (value <= _manufactureDate)
                    throw new ArgumentException("Expiry date must be after the manufacture date.");

                _expiryDate = value;
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

        private string _barcode = string.Empty;
        public string Barcode {

            get => _barcode;

            set { 
            
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Barcode cannot be empty.");

                _barcode = value;
            }
        }
        
        public Category category { get; set;}
        public Supplier supplier { get; set;}
        public Inventory inventory { get; set;}
    }
}