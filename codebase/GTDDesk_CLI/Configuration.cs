using System;
using Microsoft.Extensions.Configuration;

namespace GTDDesk_CLI
{
    public static class Configuration
    {
        public static string Directory => _instance["Directory"];

        public static bool IncludeSubDirectories => (_instance["IncludeSubDirectories"]?.ToLower() == "true");

        public static int? MaxTableWidth
        {
            get
            {
                int value;
                if (Int32.TryParse(_instance["MaxTableWidth"], out value))
                {
                    return Math.Max(0, value);
                }
                return null;
            }
        }

        private static IConfiguration _config = null;

        private static IConfiguration _instance
        {
            get
            {
                if (_config == null)
                    _config = LoadConfiguration();
                return _config;
            }
        }

        private static IConfiguration LoadConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(System.AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }
    }
}
