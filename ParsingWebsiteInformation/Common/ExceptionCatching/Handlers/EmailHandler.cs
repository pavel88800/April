using System;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace ExceptionCatching.Handlers
{
    internal class EmailHandler
    {
        public static void Send(SystemInformationDTO informationDto)
        {
            var currentDirectory = Directory.GetCurrentDirectory();

            var from = new MailAddress(" email_from", "Name");
            var to = new MailAddress("email_to");

            var m = new MailMessage(from, to);
            m.Attachments.Add(new Attachment($"{currentDirectory}\\Screenshots\\error_screenshot.jpg"));
            m.Subject = "Ошибка приложения!";
            m.Body = $"<h2>Ошибка приложения!</h2>" +
                     $"<b>Текст ошибки:</b> {informationDto.ErrorMessage} <br>" +
                     $"<b>Версия операционной системы:</b> {informationDto.OSVersion} <br>" +
                     $"<b>Имя пользователя в ОС:</b> {informationDto.UserName} <br>" +
                     $"<b>Версия NET Framework:</b> {informationDto.VersionNetFramework} <br>" +
                     $"<b>Скриншот во вложении.</b>";

            m.IsBodyHtml = true;
            var smtp = new SmtpClient("smtp.yandex.ru", 25);
            smtp.Credentials = new NetworkCredential("your_email", "your_password");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
    }
}
