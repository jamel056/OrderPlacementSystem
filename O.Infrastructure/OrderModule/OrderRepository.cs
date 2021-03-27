using O.Core.OrderModule.IRepository;
using O.Entities.Entities;
using O.Infrastructure.Data;
using O.Infrastructure.Repositories;

namespace O.Infrastructure.OrderModule
{
    public class OrderRepository : BaseRepository<OrderForm>, IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }


    }
}
