using Common.Options;

namespace Host.Services.Interfaces
{
    public interface IOrderService
    {
        int CreateOrder(CreateOrderOptions request);
    }
}