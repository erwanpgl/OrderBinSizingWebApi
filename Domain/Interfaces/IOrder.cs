using OrderBinSizingWebApi.Domain.Models;

namespace OrderBinSizingWebApi.Domain.Interfaces
{
    public interface IOrder
    {
        public int Id { get; set; }
        public List<OrderItem> Items { get; set; }
        public float RequiredBinWidth();
    }
}
