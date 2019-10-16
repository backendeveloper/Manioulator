using Contact.Response;
using MediatR;

namespace Contact.Requests
{
    public class ProductGetRequest : IRequest<ProductGetResponse>
    {
        public string ProductCode { get; set; }
    }
}