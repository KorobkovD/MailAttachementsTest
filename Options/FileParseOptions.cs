namespace MailAttachementsTest.Options
{
    /// <summary>
    /// Конфигурация файла от поставщика
    /// </summary>
    public class FileParseOptions
    {
        /// <summary>
        /// Индекс колонки Бренд
        /// </summary>
        public int VendorColumnIndex { get; set; }

        /// <summary>
        /// Индекс колонки Каталожный номер
        /// </summary>
        public int NumberColumnIndex { get; set; }

        /// <summary>
        /// Индекс колонки Описание
        /// </summary>
        public int DescriptionColumnIndex { get; set; }

        /// <summary>
        /// Индекс колонки Цена
        /// </summary>
        public int PriceColumnIndex { get; set; }

        /// <summary>
        /// Индекс колонки Наличие
        /// </summary>
        public int CountColumnIndex { get; set; }
    }
}
