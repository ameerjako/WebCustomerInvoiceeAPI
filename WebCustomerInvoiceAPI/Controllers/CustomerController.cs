using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCustomerInvoiceAPI.Data;
using WebCustomerInvoiceAPI.Models;

namespace WebCustomerInvoiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult< IEnumerable<Customer>>> GetCustomers()
        {
            return await _context.Customer.ToListAsync();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> DeleteCustomer(int id)
        {
            var itemtoDelete = await _context.Customer.FindAsync(id);

            if (itemtoDelete == null)
            {
                return NotFound();
            }

            _context.Customer.Remove(itemtoDelete);
            await _context.SaveChangesAsync();

            return Ok(itemtoDelete);
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> AddCustomer([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return NotFound();
            }
            await _context.Customer.AddAsync(customer);
            return CreatedAtAction(
                                    nameof(GetCustomer),
                                    new { id = customer.customer_id },
                                    customer);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var c = await _context.Customer.FindAsync(id);
            return c == null ? NotFound() : c;
        }

        [HttpGet("Invoices/{customerId}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetCustomerInvoices(int customerId)
        {
            var invoices = await _context.Order
                                         .Where(o => o.customer_id == customerId)
                                         .Include(o => o.Customer)
                                         .Include(o => o.Orderdetail)
                                             .ThenInclude(od => od.Product)
                                         .ToListAsync();

            return invoices.Any() ? Ok(invoices) : NotFound();
        }
    }
}
