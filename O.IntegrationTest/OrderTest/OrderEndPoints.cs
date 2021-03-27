using O.Common;
using O.Core.OrderModule.Requests;
using O.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace O.IntegrationTest.OrderTest
{
    public class OrderEndPoints : IntegrationTestSettings
    {
        #region Requests
        public OrderRequest PlaceOrderRequest()
        {
            return new OrderRequest()
            {
                CustomerName = "jameel",
                PhoneNumber = "0535549125",
                Email = "jamel_056@hotmail.com",
                AddressFrom = "Turkey, Istanbul",
                AddressTo = "Turkey, Gazi Intab",
                DateCarryOut = DateTime.Today,
                AdditionNotes = "there are extra luggages!!!",
                OrderServices = new List<OrderServicesEnum> { OrderServicesEnum.Packing, OrderServicesEnum.Moving }
            };
        }

        public OrderRequest EditOrderRequest()
        {
            return new OrderRequest()
            {
                CustomerName = "جميل",
                PhoneNumber = "0535549125",
                Email = "jamel056@gmail.com",
                AddressFrom = "Turkey, Ezmir",
                AddressTo = "Turkey, Istanbul",
                DateCarryOut = DateTime.Today,
                AdditionNotes = "there are extra luggages and some boxes!!!",
                OrderServices = new List<OrderServicesEnum> { OrderServicesEnum.Packing }
            };
        }
        #endregion

        #region Methods
        public async Task<HttpResponseMessage> Place(OrderRequest request)
        {
            return await TestClient.PostAsJsonAsync(Routes.Orders.Place, request);
        }

        public async Task<HttpResponseMessage> Edit(OrderRequest request, int id)
        {
            return await TestClient.PutAsJsonAsync(Routes.Orders.Edit.Replace("{id}", id.ToString()), request);
        }

        public async Task<HttpResponseMessage> Find(int id)
        {
            return await TestClient.GetAsync(Routes.Orders.Find.Replace("{id}", id.ToString()));

        }

        public async Task<HttpResponseMessage> Delete(int id)
        {
            return await TestClient.DeleteAsync(Routes.Orders.Delete.Replace("{id}", id.ToString()));

        }

        #endregion
    }
}
