using O.Entities.Entities;
using O.Entities.Enums;
using System;
using System.Collections.Generic;

namespace O.Core.OrderModule.Requests
{
    public class OrderRequest
    {
        public OrderRequest()
        {
            OrderServices ??= new List<OrderServicesEnum>();
        }
        public OrderForm GetModel()
        {
            return new OrderForm()
            {
                CustomerName = CustomerName,
                PhoneNumber = PhoneNumber,
                Email = Email,
                AddressFrom = AddressFrom,
                AddressTo = AddressTo,
                DateCarryOut = DateCarryOut,
                AdditionNotes = AdditionNotes
            };
        }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string AddressFrom { get; set; }
        public string AddressTo { get; set; }
        public List<OrderServicesEnum> OrderServices { get; set; }
        public DateTime DateCarryOut { get; set; }
        public string AdditionNotes { get; set; }
    }
}
