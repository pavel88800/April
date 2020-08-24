using RestSharp;

namespace ParsingWebsiteInformation.Connect
{
    /// <summary>
    ///     Класс для http подключения к сайту
    /// </summary>
    internal class HttpConnecting
    {
        /// <summary>
        ///     Подключаемся к сайту по указанной ссылке и получаем контент
        /// </summary>
        /// <returns>Контент.</returns>
        internal static string CreateHttpConnect(string url)
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);
            return response.Content;
        }
    }
}