using OrderBinSizingWebApi.Domain.Interfaces;

namespace OrderBinSizingWebApi.Application.Interfaces
{
    public interface IRepository
    {
        Task SubmitOrderAsync(IOrder order);
        Task<IOrder> GetOrderAsync(int orderId);

    }
}
