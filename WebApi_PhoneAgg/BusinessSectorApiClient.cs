using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using WebApi_PhoneAgg.Models;

namespace WebApi_PhoneAgg
{
    public class BusinessSectorApiClient
    {
        public static async Task<PhoneNumber> GetBusinessSectorAsync(string number)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://challenge-business-sector-api.meza.talkdeskstg.com/");

                PhoneNumber phonenumber = null;
                var formatters = new List<MediaTypeFormatter>() { new JsonMediaTypeFormatter() };
                HttpResponseMessage response = await client.GetAsync($"sector/{number}");
                if (response.IsSuccessStatusCode)
                {
                    phonenumber = await response.Content.ReadAsAsync<PhoneNumber>(formatters);
                }

                return phonenumber;
            }
        }

    }
}
