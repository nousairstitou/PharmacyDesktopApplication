using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models {

    public class Customer : Person {

        // CustomerId is generated automatically by the database
        public int? CustomerId { get; set; }
    }
}