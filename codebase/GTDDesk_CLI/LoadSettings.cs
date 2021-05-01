using Microsoft.Extensions.Configuration;
using GTDDesk_Core;

namespace GTDDesk_CLI
{
    public static class LoadSettings
    {
        public static Settings Run()
        {
            IConfiguration config = GetConfig();
            return new Settings()
            {
                Directory = config["Directory"]
            };
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
