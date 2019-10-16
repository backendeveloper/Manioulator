using Contact.Response;
using MediatR;

namespace Contact.Requests
{
    public class ProductUpdateRequest : IRequest<ProductUpdateResponse>
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public float Price { get; set; }
        public int ChangeStockCount { get; set; }
    }
}