using O.Entities.Enums;

namespace O.Entities.Entities
{
    public class OrderServices
    {
        public int Id { get; set; }
        public int OrderFormId { get; set; }
        public OrderForm OrderForm { get; set; }
        public OrderServicesEnum ServicesEnum { get; set; }
    }
}
