using OrderBinSizingWebApi.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderBinSizingWebApi.Domain.Models
{
    public class Product : IProduct
    {
        [Key]
        [Column("ProductType")]
        public ProductTypeEnum Id { get; set; }
        public float PackageWidth { get; set; }
        public virtual float RequiredBinWidth(int quantity)
        {
            return PackageWidth * quantity;
        }
    }
}
