using Microsoft.Extensions.Configuration;
using System.IO;

namespace MailAttachementsTest.Managers
{
    public static class ConfigurationManager
    {
        public static IConfiguration GetConfiguration()
        {
            var directory = Directory.GetCurrentDirectory();

            var builder = new ConfigurationBuilder()
                .SetBasePath(directory)
                .AddJsonFile("appsettings.json");

            return builder.Build();
        }
    }
}
