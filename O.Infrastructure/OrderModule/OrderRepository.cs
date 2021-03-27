using Microsoft.EntityFrameworkCore;
using O.Core.OrderModule.IRepository;
using O.Entities.Entities;
using O.Infrastructure.Data;
using O.Infrastructure.Repositories;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace O.Infrastructure.OrderModule
{
    public class OrderRepository : BaseRepository<OrderForm>, IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<OrderForm> GetIncludeAsync(int id)
        {
            return await _context.Orders.Include(x => x.OrderServices).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<OrderForm> GetIncludeAsync(Expression<Func<OrderForm, bool>> expression)
        {
            return await _context.Orders.Include(x => x.OrderServices).FirstOrDefaultAsync(expression);
        }

        public async Task<OrderForm> GetNoTrackingAsync(int id)
        {
            return await _context.Orders.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
