using Common.Options;
using Contact.Requests;
using Host.Services.Interfaces;
using MediatR;

namespace Host.Services
{
    public class OrderService : IOrderService
    {
        private static IMediator _mediator;

        public OrderService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public int CreateOrder(CreateOrderOptions request)
        {
            OrderCreateRequest orderCreateRequest = new OrderCreateRequest
            {
                ProductCode = request.ProductCode,
                Quantity = request.Quantity
            };
            _mediator.Send(orderCreateRequest);
            
            return 1;
        }
    }
}