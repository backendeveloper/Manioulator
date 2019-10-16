using Common.Options;

namespace Host.Services.Interfaces
{
    public interface IProductService
    {
        int CreateProduct(CreateProductOptions request);

        int GetProduct(GetProductInfoOptions request);
    }
}