using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCustomerInvoiceAPI.Models
{
    public class Order
    {
        [Key]
        public int order_id { get; set; }
        public DateTimeOffset order_date { get; set; }
        public int order_total { get; set; }

        [ForeignKey(nameof(Customer))]
        public int customer_id  { get; set; }

        public Customer Customer { get; set; }
        public ICollection<Orderdetail> Orderdetail { get; set; } = new List<Orderdetail>();
    }
}
