using MailAttachementsTest.Options;
using Microsoft.Extensions.Configuration;

namespace MailAttachementsTest.Managers
{
    public class OptionsManager
    {
        private const string EmailOptionsSectionName = "EmailOptions";
        private const string FileParseOptionsSectionName = "FileParseOptions";
        private const string ConnectionStringSectionName = "ConnectionString";

        public static EmailOptions GetEmailOptions()
        {
            var configuration = ConfigurationManager.GetConfiguration();
            var emailOptions = new EmailOptions();
            configuration.GetSection(EmailOptionsSectionName).Bind(emailOptions);
            return emailOptions;
        }

        public static FileParseOptions GetFileParseOptions()
        {
            var configuration = ConfigurationManager.GetConfiguration();
            var fileParseOptions = new FileParseOptions();
            configuration.GetSection(FileParseOptionsSectionName).Bind(fileParseOptions);
            return fileParseOptions;
        }

        public static string GetConnectionString()
        {
            var configuration = ConfigurationManager.GetConfiguration();
            return configuration[ConnectionStringSectionName];
        }
    }
}
