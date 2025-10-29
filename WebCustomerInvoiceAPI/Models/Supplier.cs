using System.ComponentModel.DataAnnotations;

namespace WebCustomerInvoiceAPI.Models
{
    public class Supplier
    {
        [Key]
        public int supplier_id {  get; set; }
        public string supplier_name { get; set; }
        public string supplier_email { get; set; }
    }
}
