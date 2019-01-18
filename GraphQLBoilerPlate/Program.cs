using System.IO;
using GraphQLBoilerplate;
using Microsoft.AspNetCore.Hosting;

namespace GraphQLBoilerPlate
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var directory = Directory.GetCurrentDirectory();

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(directory)
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
