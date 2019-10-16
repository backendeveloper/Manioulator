using Common.Options;
using Contact.Requests;
using Host.Services.Interfaces;
using MediatR;

namespace Host.Services
{
    public class ProductService : IProductService
    {
        private static IMediator _mediator;

        public ProductService(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        public int CreateProduct(CreateProductOptions request)
        {
            ProductCreateRequest productCreateRequest = new ProductCreateRequest
            {
                Price = request.Price,
                Stock = request.Stock,
                ProductCode = request.ProductCode
            };
            _mediator.Send(productCreateRequest);
            
            return 1;
        }

        public int GetProduct(GetProductInfoOptions request)
        {
            ProductGetRequest productGetRequest = new ProductGetRequest
            {
                ProductCode = request.ProductCode
            };
            _mediator.Send(productGetRequest);
            
            return 1;
        }
    }
}