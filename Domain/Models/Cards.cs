using OrderBinSizingWebApi.Domain.Interfaces;

namespace OrderBinSizingWebApi.Domain.Models
{
    public class Cards: Product, IProduct
    {
        public Cards()
        {
            Id = ProductTypeEnum.Cards;
            PackageWidth = 4.7f;
        }
    }
}
