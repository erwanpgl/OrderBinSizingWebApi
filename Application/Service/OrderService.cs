using OrderBinSizingWebApi.Application.Dto;
using OrderBinSizingWebApi.Application.Interfaces;
using OrderBinSizingWebApi.Domain.Interfaces;
using OrderBinSizingWebApi.Domain.Models;
using System.Security.Principal;

namespace OrderBinSizingWebApi.Application.Service
{
    public class OrderService : IOrderService
    {
        private readonly IRepository _repository;

        public OrderService(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<OrderDto?> GetOrderAsync(int orderId)
        {
            try
            {
                var order = await _repository.GetOrderAsync(orderId);

                Dictionary<ProductTypeEnum, int> dict_productTypes_quantity = order.Items.GroupBy(i => i.Product.Id).ToDictionary(g => g.Key, g => g.Sum(i => i.Quantity));
                return new OrderDto { Id = order.Id, Items = dict_productTypes_quantity, RequiredBinWidth = order.RequiredBinWidth() };
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task SubmitOrderAsync(OrderDto orderDto)
        {
            var order = new Order { Id = orderDto.Id, Items = new List<OrderItem>() };
            //check if any items
            var itemsDto = orderDto.Items.Where(i => i.Value > 0);
            if (!itemsDto.Any()) throw new Exception("no items for the order");

            List<OrderItem> order_items = itemsDto.Select(kv =>
               new OrderItem
                {
                    Order = order,
                    Product = kv.Key switch
                    {
                        ProductTypeEnum.Calendar => new Calendar(),
                        ProductTypeEnum.Canvas => new Canvas(),
                        ProductTypeEnum.PhotoBook => new PhotoBook(),
                        ProductTypeEnum.Cards => new Cards(),
                        ProductTypeEnum.Mug => new Mug(),
                        _ => throw new NotImplementedException(),
                    },
                    Quantity = kv.Value
                }).ToList();
            order.Items = order_items;
            await _repository.SubmitOrderAsync(order);
        }
    }
}
