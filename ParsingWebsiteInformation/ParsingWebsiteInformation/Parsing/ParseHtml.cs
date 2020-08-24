using System.Linq;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using ParsingWebsiteInformation.Connect;

namespace ParsingWebsiteInformation.Parsing
{
    /// <summary>
    ///     Класс для парсинга данных с сайта
    /// </summary>
    internal class ParseHtml
    {
        /// <summary>
        ///     Точка входа для парсинга
        /// </summary>
        internal static ProductDto GetAttr(string url)
        {
            var content = HttpConnecting.CreateHttpConnect(url);
            return GetAttrProduct(content);
        }

        /// <summary>
        ///     Получить атрибуты продукта.z
        /// </summary>
        /// <param name="content">Контент документа</param>
        /// <returns>DTO</returns>
        private static ProductDto GetAttrProduct(string content)
        {
            var parser = new HtmlParser();
            var document = parser.ParseDocument(content);

            var productName = document.QuerySelector("[class='title']").InnerHtml;
            var normalPrice = GetClearPrice(document, "[class='without-card']");
            var discount = GetClearPrice(document, "[class='with-period']");

            var manufacturerList = document.All.Where(tag => tag.LocalName == "li"
                                                             && tag.GetAttribute("class") == "property"
                                                             && tag.TextContent.StartsWith("Производитель"));

            var innerHtmlManufacturer = manufacturerList.First().InnerHtml;

            var manufacturer = parser.ParseDocument(innerHtmlManufacturer)
                .QuerySelector("[style='display:none;']").TextContent;

            return new ProductDto
            {
                ProductName = productName,
                NormalPrice = normalPrice,
                Discount = discount,
                Manufacturer = manufacturer
            };
        }

        /// <summary>
        ///     Получить очищенную цену.
        /// </summary>
        /// <param name="document">Точка для входа в документ</param>
        /// <param name="selectors">Селектор по которому будет идти поиск</param>
        /// <returns>Строка</returns>
        private static string GetClearPrice(IHtmlDocument document, string selectors)
        {
            var unclearedPrice = document.QuerySelector(selectors).Children.Last().InnerHtml;
            var clearPrice = unclearedPrice.Trim(' ', '₽');
            return clearPrice;
        }
    }
}