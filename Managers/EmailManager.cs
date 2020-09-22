using CsvHelper;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Security;
using MimeKit;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace MailAttachementsTest.Managers
{
    public class EmailManager
    {
        /// <summary>
        /// Получение сообщений с вложениями
        /// </summary>
        public static List<MimeMessage> GetMessagesWithAttachements()
        {
            var emailOptions = OptionsManager.GetEmailOptions();
            var messages = new List<MimeMessage>();

            using (var client = new ImapClient())
            {
                client.Connect(emailOptions.Host, emailOptions.Port, SecureSocketOptions.SslOnConnect);

                client.Authenticate(emailOptions.Email, emailOptions.Password);

                client.Inbox.Open(FolderAccess.ReadOnly);

                var messagesCount = client.Inbox.Count;

                for (int i = messagesCount - 1; i > messagesCount - emailOptions.LastMessagesCount; i--)
                {
                    var message = client.Inbox.GetMessage(i);
                    if (message.Attachments.Any())
                    {
                        messages.Add(message);
                    }
                }

                client.Disconnect(true);
            }

            return messages;
        }

        /// <summary>
        /// Получение стоимостей из прайса во вложении к письму формата CSV
        /// </summary>
        /// <param name="message">Сообщение с вложениями</param>
        /// <param name="delimiter">Разделитель CSV</param>
        public static List<PriceItem> GetPriceItemsFromCsvAttachement(MimeMessage message, string delimiter = ";")
        {
            var priceItems = new List<PriceItem>();

            var csvExtension = ".csv";

            foreach (var attachment in message.Attachments.Where(x => x is MimePart))
            {
                var part = (MimePart)attachment;
                var fileName = part.FileName;
                var fileInfo = new FileInfo(fileName);

                if (fileInfo.Extension == csvExtension)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        part.Content.DecodeTo(memoryStream);
                        memoryStream.Position = 0;

                        using (var streamReader = new StreamReader(memoryStream))
                        using (var csv = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                        {
                            csv.Configuration.Delimiter = delimiter;
                            var isHeader = true;

                            while (csv.Read())
                            {
                                if (!isHeader)
                                {
                                    priceItems.Add(PriceItemManager.GetItemFromCsvRow(csv));
                                }
                                else
                                {
                                    isHeader = false;
                                }
                            }
                        }
                    }
                }
            }

            return priceItems;
        }
    }
}
