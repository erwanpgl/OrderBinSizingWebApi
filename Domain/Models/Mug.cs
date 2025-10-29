using OrderBinSizingWebApi.Domain.Interfaces;

namespace OrderBinSizingWebApi.Domain.Models
{
    public class Mug: Product, IProduct
    {
        private int _mugsPerStack = 4;
        public Mug()
        {
            Id = ProductTypeEnum.Mug;
            PackageWidth = 94;
        }
        public override float RequiredBinWidth(int quantity)
        {
            int stacksNeeded = (int)Math.Ceiling((double)quantity / _mugsPerStack);
            return PackageWidth * stacksNeeded;
        }
    }
}
