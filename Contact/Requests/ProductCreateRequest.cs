using Contact.Response;
using MediatR;

namespace Contact.Requests
{
    public class ProductCreateRequest : IRequest<ProductCreateResponse>
    {
        public string ProductCode { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
    }
}