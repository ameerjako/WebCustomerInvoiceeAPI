using System.ComponentModel.DataAnnotations;

namespace WebCustomerInvoiceAPI.Models
{
    public class Customer
    {
        [Key]
        public int customer_id { get; set; }
        public string customer_name { get; set; }
        public int customer_phone { get; set; }
        public string customer_email { get; set; }


    }
}
