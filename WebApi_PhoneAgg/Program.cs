using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using WebApi_PhoneAgg.FileReader;

namespace WebApi_PhoneAgg
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ReadFromFile.Read();
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls("http://*:8080");
    }
}
