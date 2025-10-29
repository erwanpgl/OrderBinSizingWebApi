using OrderBinSizingWebApi.Domain.Interfaces;

namespace OrderBinSizingWebApi.Domain.Models
{
    public class Calendar: Product, IProduct
    {
        public Calendar()
        {
            Id = ProductTypeEnum.Calendar;
            PackageWidth = 10;
        }
    }
}
