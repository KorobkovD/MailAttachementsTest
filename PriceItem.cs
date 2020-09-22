namespace MailAttachementsTest
{
    /// <summary>
    /// Элемент прайса
    /// </summary>
    public class PriceItem
    {
        /// <summary>
        /// Внутренний идентификатор
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Бренд
        /// </summary>
        public string Vendor { get; set; }

        /// <summary>
        /// Каталожный номер
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Бренд для поиска
        /// </summary>
        public string SearchVendor { get; set; }

        /// <summary>
        /// Номер для поиска
        /// </summary>
        public string SearchNumber { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Стоимость
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Наличие
        /// </summary>
        public int Count { get; set; }
    }
}
