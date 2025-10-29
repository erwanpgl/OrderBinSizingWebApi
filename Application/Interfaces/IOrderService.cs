using OrderBinSizingWebApi.Application.Dto;
using OrderBinSizingWebApi.Domain.Interfaces;

namespace OrderBinSizingWebApi.Application.Interfaces
{
    public interface IOrderService
    {
        Task SubmitOrderAsync(OrderDto order);
        Task<OrderDto?> GetOrderAsync(int orderId);
    }
}
