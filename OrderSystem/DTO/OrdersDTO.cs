using O.Entities.Entities;
using O.Entities.Enums;
using System;
using System.Collections.Generic;

namespace OrderSystem.DTO
{
    public class OrdersDTO
    {
        public OrdersDTO(OrderForm order)
        {
            Id = order.Id;
            CustomerName = order.CustomerName;
            PhoneNumber = order.PhoneNumber;
            Email = order.Email;
            AddressFrom = order.AddressFrom;
            AddressTo = order.AddressTo;
            DateCarryOut = order.DateCarryOut;
            AdditionNotes = order.AdditionNotes;
            OrderServices = new List<OrderServicesEnum>();

            if (order.OrderServices != null)
            {
                foreach (var item in order.OrderServices)
                {
                    OrderServices.Add(item.ServicesEnum);
                }
            }

        }
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string AddressFrom { get; set; }
        public string AddressTo { get; set; }
        public IList<OrderServicesEnum> OrderServices { get; set; }
        public DateTime DateCarryOut { get; set; }
        public string AdditionNotes { get; set; }
    }
}
