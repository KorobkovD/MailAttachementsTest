using MailAttachementsTest.Managers;
using System;
using System.Collections.Generic;

namespace MailAttachementsTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var priceItems = new List<PriceItem>();

            var messagesWithAttachements = EmailManager.GetMessagesWithAttachements();
            foreach (var message in messagesWithAttachements)
            {
                var priceItemsForMessage = EmailManager.GetPriceItemsFromCsvAttachement(message);
                priceItems.AddRange(priceItemsForMessage);
            }
            DatabaseManager.WritePriceItemsInDatabase(priceItems);

            Console.WriteLine($"Добавлено {priceItems.Count} записей");
        }
    }
}
