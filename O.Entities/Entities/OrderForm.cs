using System;
using System.Collections.Generic;

namespace O.Entities.Entities
{
    public class OrderForm
    {
        public OrderForm()
        {

        }
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string AddressFrom { get; set; }
        public string AddressTo { get; set; }
        public ICollection<OrderServices> OrderServices { get; set; }
        public DateTime DateCarryOut { get; set; }
        public string AdditionNotes { get; set; }
    }
}
