using OrderBinSizingWebApi.Domain.Interfaces;

namespace OrderBinSizingWebApi.Domain.Models
{
    public class Canvas: Product, IProduct
    {
        public Canvas()
        {
            Id = ProductTypeEnum.Canvas;
            PackageWidth = 16;
        }
    }
}
