using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using static EF.Context;

namespace EF.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController
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
    }
}
