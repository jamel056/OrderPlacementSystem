using O.Core.IRepositories;
using O.Entities.Entities;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace O.Core.OrderModule.IRepository
{
    public interface IOrderRepository : IBaseRepository<OrderForm>
    {
        Task<OrderForm> GetIncludeAsync(int id);
        Task<OrderForm> GetIncludeAsync(Expression<Func<OrderForm, bool>> expression);
        Task<OrderForm> GetNoTrackingAsync(int id);
    }
}
