using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi_PhoneAgg.Models;
using WebApi_PhoneAgg.FileReader;
using System;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi_PhoneAgg.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AggregateController : ControllerBase
    {
        private readonly AggregateContext _context;

        public AggregateController(AggregateContext context) => _context = context;
        
        // GET: api/aggregate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhoneNumber>>> GetAggregateItems()
        {
            return await _context.PhoneNumbers.ToListAsync();
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult<IEnumerable<PhoneNumber>>> PostAggregateItem([FromBody] string[] items)
        {
            _context.PhoneNumbers.RemoveRange(_context.PhoneNumbers);
            _context.SaveChanges();

            foreach (string item in items)
            {
                //_context.PhoneNumbers.Add(new PhoneNumber(){ Number = item.TrimStart('+') });
                PhoneNumber phonenumber = await BusinessSectorApiClient.GetBusinessSectorAsync(item);
                if (phonenumber != null)
                {
                    phonenumber.Prefix = ReadFromFile.Prefixes.First(p => phonenumber.Number.TrimStart('+').StartsWith(p));
                    _context.PhoneNumbers.Add(phonenumber);
                    await _context.SaveChangesAsync();
                }
            }

            object response = _context.Aggregate();
            return Ok(_context.Aggregate());
        }

    }
}
