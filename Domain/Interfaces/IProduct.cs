using OrderBinSizingWebApi.Domain.Models;

namespace OrderBinSizingWebApi.Domain.Interfaces
{
    public interface IProduct
    {
        public ProductTypeEnum Id { get; set; }
        float PackageWidth { get; set; }
        float RequiredBinWidth(int quantity);
    }
}
