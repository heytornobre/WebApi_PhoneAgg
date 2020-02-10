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

        internal dynamic Aggregate()
        {
            //Response response = new Response() { Prefixes = new List<Prefix>()};
            dynamic prefixes = new System.Dynamic.ExpandoObject();

            foreach (string prefix in PhoneNumbers.Select(p => p.Prefix).Distinct())
            {
                var temp = PhoneNumbers.Where(t => t.Prefix == prefix)
                            .Select(s => s.Sector).GroupBy(g => g)
                            .Select(x => new KeyValuePair<string, int>(x.Key, x.Count())).ToDictionary(d => d.Key, d => d.Value);

                Sector sector = new Sector()
                {
                    Technology = temp.TryGetValue("Technology", out int value) ? value : (int?)null,
                    Clothing = temp.TryGetValue("Clothing", out value) ? value : (int?)null,
                    Banking = temp.TryGetValue("Banking", out value) ? value : (int?)null
                };

                //response.Prefixes.Add(new Prefix { Number = prefix,
                //                                   Sectors = sector
                //}
                //);

                ((IDictionary<string, object>)prefixes).Add(prefix, sector);
            }

            return prefixes;
        }
    }
}
