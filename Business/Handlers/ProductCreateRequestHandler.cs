using System.IO;
using System.Threading.Tasks;
using Common.Handlers;
using Contact.Requests;
using Contact.Response;
using Data;
using Data.Entities;

namespace Business.Handlers
{
    public class ProductCreateRequestHandler : BaseHandler<ProductCreateRequest, ProductCreateResponse>
    {
        private readonly DataContext _dataContext;
        private readonly TextWriter _textWriter;

        public ProductCreateRequestHandler(DataContext dataContext, TextWriter textWriter)
        {
            _dataContext = dataContext;
            _textWriter = textWriter;
        }

        public override Task<ProductCreateResponse> Execute(ProductCreateRequest request)
        {
            var product = new Product
            {   
                Price = request.Price,
                Stock = request.Stock,
                ProductCode = request.ProductCode
            };
            _dataContext.Products.Add(product);
            _dataContext.SaveChanges();

            ProductCreateResponse productCreateResponse = new ProductCreateResponse()
            {
                Price = request.Price,
                Stock = request.Stock,
                ProductCode = request.ProductCode
            };
            
            _textWriter.WriteLine("Product created; code {0}, price {1}, stock {2}", productCreateResponse.ProductCode, productCreateResponse.Price, productCreateResponse.Stock);
            
            return Task.FromResult(productCreateResponse);
        }
    }
}