using System;
using ExceptionCatching.Handlers;

namespace ExceptionCatching
{
    /// <summary>
    ///     Главный обработчик.
    /// </summary>
    public class ClientException
    {
        /// <summary>
        ///     Инициализируем скриншоты и отправку писем.
        /// </summary>
        public static void Process()
        {
            AppDomain.CurrentDomain.UnhandledException += ( sender, args) =>
            {
                ScreenshotHandler.CreateScheenshot();
                var error = args.ExceptionObject.ToString();
                var information = GetSystemInformation(error);
                EmailHandler.Send(information);
            };
        }

        /// <summary>
        /// Получаем информацию о системе.
        /// </summary>
        /// <param name="errorMessage">Текст ошибки</param>
        /// <returns><see cref="SystemInformationDTO"/></returns>
        private static SystemInformationDTO GetSystemInformation(string errorMessage)
        {
            return new SystemInformationDTO
            {
                 UserName = Environment.UserName,
                 OSVersion = Environment.OSVersion,
                 VersionNetFramework = Environment.Version,
                 ErrorMessage = errorMessage
            };
        }
    }
}