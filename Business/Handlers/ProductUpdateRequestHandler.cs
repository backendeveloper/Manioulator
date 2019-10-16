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
    public class ProductUpdateRequestHandler : BaseHandler<ProductUpdateRequest, ProductUpdateResponse>
    {
        private readonly DataContext _dataContext;

        public ProductUpdateRequestHandler(DataContext dataContext, TextWriter textWriter)
        {
            _dataContext = dataContext;
        }

        public override Task<ProductUpdateResponse> Execute(ProductUpdateRequest request)
        {
            Product product = _dataContext.Products.FirstOrDefault(x => x.ProductId == request.ProductId);

            product.Price = request.Price;
            product.Stock -= request.ChangeStockCount;

            _dataContext.Products.Update(product);
            _dataContext.SaveChanges();

            ProductUpdateResponse productUpdateResponse = new ProductUpdateResponse
            {
                ProductCode = product.ProductCode,
                Price = product.Price,
                Stock = product.Stock
            };
            
            return Task.FromResult(productUpdateResponse);
        }
    }
}