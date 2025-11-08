using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models {

    public class Inventory {

        public int? InventoryId { get; private set; }

        private string? _inventoryName;
        public string? InventoryName {

            get => _inventoryName;

            set {

                if(string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(nameof(InventoryName) , "Inventory Name cannot be null or empty.");

                _inventoryName = value;
            }
        }

        private string? _location;
        public string? Location {

            get => _location;

            set {

                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(nameof(Location) ,"location cannot be null or empty.");

                _location = value;
            }
        }

        private int _capacity;
        public int Capacity {

            get => _capacity;

            set {

                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(Capacity) ,"Capacity must be a positive integer.");

                _capacity = value;
            }
        }
    }
}