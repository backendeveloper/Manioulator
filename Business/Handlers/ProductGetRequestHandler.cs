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
    public class ProductGetRequestHandler : BaseHandler<ProductGetRequest, ProductGetResponse>
    {
        private readonly DataContext _dataContext;
        private readonly TextWriter _textWriter;

        public ProductGetRequestHandler(DataContext dataContext, TextWriter textWriter)
        {
            _dataContext = dataContext;
            _textWriter = textWriter;
        }

        public override Task<ProductGetResponse> Execute(ProductGetRequest request)
        {
            Product product = _dataContext.Products.FirstOrDefault(x => x.ProductCode == request.ProductCode);  

            ProductGetResponse productGetResponse = new ProductGetResponse
            {
                ProductCode = product.ProductCode,
                Price = product.Price,
                Stock = product.Stock
            };

            _textWriter.WriteLine("Product {0} info; price {1}, stock {2}", productGetResponse.ProductCode, productGetResponse.Price, productGetResponse.Stock);
            
            return Task.FromResult(productGetResponse);
        }
    }
}