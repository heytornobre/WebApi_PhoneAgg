using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebApi_PhoneAgg.Models
{
    public class AggregateContext :DbContext
    {
        public AggregateContext(DbContextOptions<AggregateContext> options)
            : base(options)
        {
        }

        public DbSet<PhoneNumber> PhoneNumbers { get; set; }

        internal Response Aggregate()
        {
            Response response = new Response() { Prefixes = new List<Prefix>()};
            foreach (string prefix in PhoneNumbers.Select(p=>p.Prefix).Distinct())
            {
                var temp = PhoneNumbers.Where(t => t.Prefix == prefix)
                            .Select(s=> s.Sector).GroupBy(g=>g)
                            .Select(x=> new KeyValuePair<string,int>(x.Key, x.Count()));
                response.Prefixes.Add(new Prefix { Number = int.Parse(prefix), Sectors = temp.ToList() }); 
            }

            return response;
        }
    }
}
