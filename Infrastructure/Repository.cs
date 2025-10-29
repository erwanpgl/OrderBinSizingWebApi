using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OrderBinSizingWebApi.Application.Interfaces;
using OrderBinSizingWebApi.Application.Service;
using OrderBinSizingWebApi.Domain.Interfaces;
using OrderBinSizingWebApi.Domain.Models;

namespace OrderBinSizingWebApi.infrastructure
{
    public class Repository : IRepository //<T> where T : class, IOrder
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<OrderService> _logger;

        public Repository(AppDbContext context, ILogger<OrderService> logger)
        {
            _dbContext = context;
            _logger = logger;
        }

        public async Task SubmitOrderAsync(IOrder order)
        {
            //to not include already existing products:
            foreach (var item in order.Items)
            {
                var existingProduct = await _dbContext.Products
                    .FindAsync(item.Product.Id);

                if (existingProduct != null)
                {                    
                    item.Product = existingProduct;
                }
                else
                {
                    _dbContext.Products.Add(item.Product);
                }
            }

            try
            {
                await _dbContext.Orders.AddAsync((Order)order);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error submitting order with ID {OrderId}", order.Id);
                throw;
            }            
        }

        public async Task<IOrder> GetOrderAsync(int orderId)
        {            
            try
            {
                var order = await _dbContext.Orders
                                .Include(o => o.Items)
                                .ThenInclude(oi => oi.Product)
                                .FirstOrDefaultAsync(o => o.Id == orderId);
                if (order == null) throw new KeyNotFoundException();
                return order;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving order with ID {OrderId}", orderId);
                throw;
            }            
        }
    }
}
