using FluentAssertions;
using FluentAssertions.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace O.IntegrationTest.OrderTest
{
    public class OrderTests : OrderEndPoints
    {
        #region main methods scenarios 
        [Fact]
        public async Task Place_Order()
        {
            // Arrange 
            var request = PlaceOrderRequest();
            // Act
            var response = await Place(request);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var order = await response.Content.ReadAsStringAsync();
            var actual = JToken.Parse(order);
            actual.SelectToken("customerName").Should().HaveValue(request.CustomerName.ToString());
            actual.SelectToken("email").Should().NotBeNull();
            actual.SelectToken("phoneNumber").Should().HaveValue(request.PhoneNumber.ToString());
        }

        [Fact]
        public async Task Edit_Order()
        {
            // Arrange
            var createRequest = PlaceOrderRequest();
            var updateRequest = EditOrderRequest();

            var createResponse = await Place(createRequest);

            createResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            var order = await createResponse.Content.ReadAsStringAsync();
            var actual = JToken.Parse(order);
            actual.SelectToken("customerName").Should().HaveValue(createRequest.CustomerName.ToString());
            var orderId = actual["id"].Value<int>();

            // Act
            var response = await Edit(updateRequest, orderId);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            order = await response.Content.ReadAsStringAsync();
            actual = JToken.Parse(order);
            actual.SelectToken("customerName").Should().HaveValue(updateRequest.CustomerName.ToString());

            // Act
            response = await Edit(updateRequest, 1000000);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task Place_Order_And_Find_It()
        {
            // Arrange 
            var request = PlaceOrderRequest();
            // Act
            var createResponse = await Place(request);

            // Assert
            createResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            var order = await createResponse.Content.ReadAsStringAsync();
            var actual = JToken.Parse(order);
            actual.SelectToken("customerName").Should().HaveValue(request.CustomerName.ToString());

            var orderId = actual["id"].Value<int>();

            // Act
            var response = await Find(orderId);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            order = await response.Content.ReadAsStringAsync();
            actual = JToken.Parse(order);
            actual.SelectToken("customerName").Should().HaveValue(request.CustomerName.ToString());
        }

        [Fact]
        public async Task Place_Order_And_Delete_It()
        {
            // Arrange 
            var request = PlaceOrderRequest();
            bool success = true;
            // Act
            var createResponse = await Place(request);

            // Assert
            createResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            var order = await createResponse.Content.ReadAsStringAsync();
            var actual = JToken.Parse(order);
            actual.SelectToken("customerName").Should().HaveValue(request.CustomerName.ToString());

            var orderId = actual["id"].Value<int>();

            // Act
            var deleteResponse = await Delete(orderId);

            // Assert
            deleteResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            order = await deleteResponse.Content.ReadAsStringAsync();
            actual = JToken.Parse(order);
            actual.SelectToken("isDeleted").Should().HaveValue(success.ToString());

            // Act
            var response = await Find(orderId);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
        #endregion

        #region other scenarios
        [Fact]
        public async Task Place_Order_With_Request_Null_Fields()
        {
            // Arrange 
            var request = PlaceOrderRequest();
            request.PhoneNumber = null;
            // Act
            var response = await Place(request);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        }

        [Fact]
        public async Task Edit_Order_With_Request_Null_Fields()
        {
            // Arrange
            var createRequest = PlaceOrderRequest();
            var updateRequest = EditOrderRequest();
            updateRequest.PhoneNumber = null;

            var createResponse = await Place(createRequest);

            createResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            var order = await createResponse.Content.ReadAsStringAsync();
            var actual = JToken.Parse(order);
            actual.SelectToken("customerName").Should().HaveValue(createRequest.CustomerName.ToString());
            var orderId = actual["id"].Value<int>();

            // Act
            var response = await Edit(updateRequest, orderId);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        #endregion
    }
}
