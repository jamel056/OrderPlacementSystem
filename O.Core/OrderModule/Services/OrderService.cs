using O.Core.OrderModule.IRepository;
using O.Core.OrderModule.Requests;
using O.Entities.Entities;
using System.Threading.Tasks;

namespace O.Core.OrderModule.Services
{
    public interface IOrderService
    {
        Task<OrderForm> PlaceOrder(OrderRequest request);
        Task<OrderForm> GetOrder(int id);
        Task<OrderForm> GetNoTrackingAsync(int id);
        Task<OrderForm> EditOrder(OrderRequest request, int id);
        Task<bool> DeleteOrder(int id);
        Task<OrderForm> GetOrder(string name);
    }

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderServicesRepository _orderServicesRepository;

        public OrderService(IOrderRepository orderRepository, IOrderServicesRepository orderServicesRepository)
        {
            _orderRepository = orderRepository;
            _orderServicesRepository = orderServicesRepository;
        }
        public async Task<bool> DeleteOrder(int id)
        {
            var orderFromDb = await _orderRepository.GetAsync(id);
            if (orderFromDb == null) return false;

            _orderRepository.Delete(orderFromDb);
            var isDeleted = await _orderRepository.SaveAsync();
            return isDeleted > 0;
        }

        public async Task<OrderForm> EditOrder(OrderRequest request, int id)
        {
            var model = request.GetModel();
            model.Id = id;
            _orderRepository.Update(model);
            var isEdited = await _orderRepository.SaveAsync();

            if (request.OrderServices != null)
            {
                await _orderServicesRepository.DeleteListOfServices(model.Id);

                await _orderServicesRepository.AddListOfServices(request.OrderServices, model.Id);
            }
            return model;
        }

        public async Task<OrderForm> GetOrder(int id)
        {
            var orderFromDb = await _orderRepository.GetIncludeAsync(id);
            return orderFromDb;
        }

        public async Task<OrderForm> GetNoTrackingAsync(int id)
        {
            var orderFromDb = await _orderRepository.GetNoTrackingAsync(id);
            return orderFromDb;
        }

        public async Task<OrderForm> GetOrder(string name)
        {
            var orderFromDb = await _orderRepository
                .GetIncludeAsync(x => x.CustomerName.Trim().ToLower().Equals(name.Trim().ToLower()));
            return orderFromDb;
        }

        public async Task<OrderForm> PlaceOrder(OrderRequest request)
        {
            var model = request.GetModel();
            await _orderRepository.AddAsync(model);
            var isAdded = await _orderRepository.SaveAsync();

            if (isAdded > 0 && request.OrderServices != null)
            {
                await _orderServicesRepository.AddListOfServices(request.OrderServices, model.Id);
            }

            return model;
        }
    }
}
