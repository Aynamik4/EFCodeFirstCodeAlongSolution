using System;
using System.Collections.Generic;
using System.Text;

namespace EFCodeFirstCodeAlong.Models
{
    class Customer
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<CustomerAddress> CustomerAddresses { get; set; }

        public Customer()
        {
            CustomerAddresses = new List<CustomerAddress>();
        }
    }
}
