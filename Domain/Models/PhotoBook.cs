using OrderBinSizingWebApi.Domain.Interfaces;

namespace OrderBinSizingWebApi.Domain.Models
{
    public class PhotoBook : Product, IProduct
    {
        public PhotoBook()
        {
            Id = ProductTypeEnum.PhotoBook;
            PackageWidth= 19;
        }
       
    }
}
