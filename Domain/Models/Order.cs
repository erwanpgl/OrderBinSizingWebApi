using OrderBinSizingWebApi.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace OrderBinSizingWebApi.Domain.Models
{
    public class Order : IOrder
    {
        public int Id { get; set; }
        public required List<OrderItem> Items { get; set; }
        public float RequiredBinWidth()
        {
            float totalBinWidth = 0;

            foreach(var item in Items)
            {
                IProduct product;

                switch (item.Product.Id)
                {
                    case ProductTypeEnum.PhotoBook:
                        product = new PhotoBook();
                        break;
                    case ProductTypeEnum.Mug:
                        product = new Mug();
                        break;
                    case ProductTypeEnum.Cards:
                        product = new Cards();
                        break;
                    case ProductTypeEnum.Canvas:
                        product = new Canvas();
                        break;
                    case ProductTypeEnum.Calendar:
                        product = new Calendar();
                        break;
                    default:
                        throw new NotImplementedException();
                }
                totalBinWidth += product.RequiredBinWidth(item.Quantity);
            }
            return totalBinWidth;
        }
    }

   
}
