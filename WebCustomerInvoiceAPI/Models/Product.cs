using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCustomerInvoiceAPI.Models
{
    public class Product
    {
        [Key]
        public long product_id {  get; set; }
        public string product_name { get; set; }
        public int product_price { get; set; }
        public int product_stock {  get; set; }

        [ForeignKey(nameof(Supplier))]
        public int supplier_id { get; set; }
    }
}
