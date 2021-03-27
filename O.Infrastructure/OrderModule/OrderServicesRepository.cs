using O.Core.OrderModule.IRepository;
using O.Entities.Entities;
using O.Infrastructure.Data;
using O.Infrastructure.Repositories;

namespace O.Infrastructure.OrderModule
{
    public class OrderServicesRepository : BaseRepository<OrderServices>, IOrderServicesRepository
    {
        private readonly AppDbContext _context;

        public OrderServicesRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }


    }
}
