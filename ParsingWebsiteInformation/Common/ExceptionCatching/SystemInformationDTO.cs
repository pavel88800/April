using System;

namespace ExceptionCatching
{
    /// <summary>
    ///     ДТО для передачи информации о системе.
    /// </summary>
    internal class SystemInformationDTO
    {
        /// <summary>
        ///     Версия операционной системы
        /// </summary>
        public OperatingSystem OSVersion { get; set; }

        /// <summary>
        ///     Имя пользователя зарегестрированного в системе
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        ///     Версия операционной системы.
        /// </summary>
        public Version VersionNetFramework { get; set; }

        public string ErrorMessage { get; set; }
    }
}