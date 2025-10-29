using OrderBinSizingWebApi.Domain.Interfaces;
using OrderBinSizingWebApi.Domain.Models;

namespace OrderBinSizingWebApi.Application.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }
        public required Dictionary<ProductTypeEnum, int> Items { get; set; }
        public float RequiredBinWidth { get; set; }
    }
}
