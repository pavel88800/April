namespace ParsingWebsiteInformation.Parsing
{
    /// <summary>
    ///     ДТО сохранения значений для товара.
    /// </summary>
    internal class ProductDto
    {
        /// <summary>
        ///     Наименование продукта
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        ///     Нормальная цена (без скидки.)
        /// </summary>
        public string NormalPrice { get; set; }

        /// <summary>
        ///     Цена со скидкой
        /// </summary>
        public string Discount { get; set; }

        /// <summary>
        ///     Производитель
        /// </summary>
        public string Manufacturer { get; set; }
    }
}