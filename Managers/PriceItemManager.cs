using CsvHelper;
using System.Text.RegularExpressions;

namespace MailAttachementsTest.Managers
{
    internal class PriceItemManager
    {
        private const string NonDigitsAndLettersRegexp = "[^a-zA-Z0-9а-яА-ЯёЁ]";
        private const string LtGtRegexp = "[<>]";

        /// <summary>
        /// Получение элемента прайса из стоки csv
        /// </summary>
        public static PriceItem GetItemFromCsvRow(CsvReader csvRow)
        {
            var fileParseOptions = OptionsManager.GetFileParseOptions();

            var countString = csvRow.GetField<string>(fileParseOptions.CountColumnIndex);
            countString = countString.IndexOf("-") >= 0 ?
                countString.Split("-")[1] :
                Regex.Replace(countString, LtGtRegexp, string.Empty);
            int.TryParse(countString, out var count);
            decimal.TryParse(csvRow.GetField<string>(fileParseOptions.PriceColumnIndex), out var price);
            var vendor = csvRow.GetField<string>(fileParseOptions.VendorColumnIndex).ToUpper();
            var searchVendor = Regex.Replace(vendor, NonDigitsAndLettersRegexp, string.Empty);
            var number = csvRow.GetField<string>(fileParseOptions.NumberColumnIndex).ToUpper();
            var searchNumber = Regex.Replace(number, NonDigitsAndLettersRegexp, string.Empty);
            var description = csvRow.GetField<string>(fileParseOptions.DescriptionColumnIndex);
            if (description.Length > 512)
            {
                description = description.Substring(0, 512);
            }

            return new PriceItem
            {
                Vendor = vendor,
                SearchVendor = searchVendor,
                Number = number,
                SearchNumber = searchNumber,
                Description = description,
                Price = price,
                Count = count
            };
        }
    }
}
