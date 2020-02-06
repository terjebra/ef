using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static EF.Context;

namespace EF.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : Controller
    {
        private readonly Context _context;

        public CustomersController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IList<Customer> GetCustomers()
        {
            return _context.Set<Customer>().ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomer(int id)
        {
            return _context.Set<Customer>().FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CustomerDTO customer)
        {
            var domainCustomer = new Customer
            {
                Name = new CustomerName
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName
                }
            };

            _context.Add(domainCustomer);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCustomer), new { id = domainCustomer.Id }, domainCustomer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, CustomerDTO customer)
        {
            var domainCustomer = _context.Set<Customer>().FirstOrDefault(x => x.Id == id);

            if(domainCustomer == null)
            {
                return NotFound();
            }


            domainCustomer.Name = new CustomerName
            {
                LastName = customer.LastName,
                FirstName = customer.FirstName
            };

            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var domainCustomer = _context.Set<Customer>().FirstOrDefault(x => x.Id == id);

            if (domainCustomer == null)
            {
                return NotFound();
            }

            _context.Set<Customer>().Remove(domainCustomer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }


    public class CustomerDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
