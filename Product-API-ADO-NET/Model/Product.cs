using System.ComponentModel.DataAnnotations;

namespace Product_API_ADO_NET.Model
{
    public class Product
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string ProductName { get; set; }

        [StringLength(200)]
        public string? ShortDescription { get; set; }

        [StringLength(500)]
        public string? LongDescription { get; set; }

        [Required, StringLength(30)]
        public string ProductCode { get; set; }

        [Required]
        public decimal SalePrice { get; set; }
        public decimal Weight { get; set; }
        public string Unit { get; set; }
        public string Brand { get; set; }
        public int ProductWarranty { get; set; }
        public decimal VAT { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
