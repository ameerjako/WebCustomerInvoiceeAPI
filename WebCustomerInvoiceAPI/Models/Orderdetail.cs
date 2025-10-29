using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebCustomerInvoiceAPI.Models
{
    public class Orderdetail
    {
        [Key]
        public int orderdetail_id { get; set; }

        [ForeignKey(nameof(Order))]
        public int order_id { get; set; }

        [ForeignKey(nameof(Product))]
        public long product_id { get; set; }

        public int quantity { get; set; }
        public int price { get; set; }

        [JsonIgnore]
        public Order Order { get; set; }
        public Product Product { get; set; }

    }
}
