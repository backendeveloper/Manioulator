using Contact.Response;
using MediatR;

namespace Contact.Requests
{
    public class OrderCreateRequest : IRequest<OrderCreateResponse>
    {
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
    }
}