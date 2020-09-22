using MailAttachementsTest.Data;
using MailAttachementsTest.Entities;
using System.Collections.Generic;

namespace MailAttachementsTest.Managers
{
    internal class DatabaseManager
    {
        /// <summary>
        /// Запись данных по прайсу в базу
        /// </summary>
        /// <param name="priceItems">Стоимости из прайса</param>
        public static void WritePriceItemsInDatabase(IEnumerable<PriceItem> priceItems)
        {
            using (var database = new PricesDbContext())
            {
                database.PriceItems.AddRange(priceItems);
                database.SaveChanges();
            }
        }
    }
}
