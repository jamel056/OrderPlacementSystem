using O.Core.IRepositories;
using O.Entities.Entities;
using O.Entities.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace O.Core.OrderModule.IRepository
{
    public interface IOrderServicesRepository : IBaseRepository<OrderServices>
    {
        Task<bool> AddListOfServices(List<OrderServicesEnum> listServices, int orderId);
        Task<bool> DeleteListOfServices(int orderId);
    }
}
