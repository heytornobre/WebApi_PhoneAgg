using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi_PhoneAgg.Models;
using WebApi_PhoneAgg.FileReader;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi_PhoneAgg.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AggregateController : ControllerBase
    {
        private readonly AggregateContext _context;

        public AggregateController(AggregateContext context) => _context = context;
        
        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> PostAggregateItem([FromBody] string[] items)
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

            return GetResponseString(_context.Aggregate());

            //return _context.Aggregate();
        }

        public IActionResult GetResponseString(dynamic response)
        {
            var jsonString = JsonConvert.SerializeObject(response, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore});
            return Content(jsonString,"application/json");
        }
    }
}
