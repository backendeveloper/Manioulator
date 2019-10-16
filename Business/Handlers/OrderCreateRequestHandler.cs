using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Common.Handlers;
using Contact.Requests;
using Contact.Response;
using Data;
using Data.Entities;

namespace Business.Handlers
{
    public class OrderCreateRequestHandler : BaseHandler<OrderCreateRequest, OrderCreateResponse>
    {
        private readonly DataContext _dataContext;
        private readonly TextWriter _textWriter;

        public OrderCreateRequestHandler(DataContext dataContext, TextWriter textWriter)
        {
            _dataContext = dataContext;
            _textWriter = textWriter;
        }

        public override Task<OrderCreateResponse> Execute(OrderCreateRequest request)
        {
            Order order = new Order
            {   
               ProductCode = request.ProductCode,
               Quantity = request.Quantity
            };
            _dataContext.Orders.Add(order);
            _dataContext.SaveChanges();

            OrderCreateResponse orderCreateResponse = new OrderCreateResponse
            {
                ProductCode = order.ProductCode,
                Quantity = order.Quantity
            };

            _textWriter.WriteLine("Order created; product {0}, quantity {1}", orderCreateResponse.ProductCode, orderCreateResponse.Quantity);
            
            return Task.FromResult(orderCreateResponse);
        }
    }
}