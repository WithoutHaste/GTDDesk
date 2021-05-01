using System;
using Microsoft.Extensions.Configuration;
using GTDDesk_Core;

namespace GTDDesk_CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] projects = ListProjects.Run();
            foreach (string project in projects)
            {
                Console.WriteLine(project);
            }

            IConfiguration config = GetConfig();
            Console.WriteLine(config["Directory"]);
        }

        private static IConfiguration GetConfig()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(System.AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }
    }
}
