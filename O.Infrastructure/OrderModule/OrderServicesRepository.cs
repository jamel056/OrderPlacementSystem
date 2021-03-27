using O.Core.OrderModule.IRepository;
using O.Entities.Entities;
using O.Entities.Enums;
using O.Infrastructure.Data;
using O.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace O.Infrastructure.OrderModule
{
    public class OrderServicesRepository : BaseRepository<OrderServices>, IOrderServicesRepository
    {
        private readonly AppDbContext _context;

        public OrderServicesRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> AddListOfServices(List<OrderServicesEnum> listServices, int orderId)
        {
            var orderServicesList = new List<OrderServices>();
            foreach (var item in listServices)
            {
                orderServicesList.Add(new OrderServices
                {
                    OrderFormId = orderId,
                    ServicesEnum = item
                });
            }

            _context.OrderServices.AddRange(orderServicesList);
            var isAdded = await _context.SaveChangesAsync();
            return isAdded > 0;
        }

        public async Task<bool> DeleteListOfServices(int orderId)
        {
            var listOfServices = _context.OrderServices.Where(x => x.OrderFormId == orderId).ToList();
            _context.OrderServices.RemoveRange(listOfServices);
            var isDeleted = await _context.SaveChangesAsync();
            return isDeleted > 0;
        }
    }
}
