using System;
using System.Collections.Generic;
using System.IO;
using OpenPop.Mime;
using OpenPop.Pop3;

namespace DownloadAttachmentApp
{
    /// <summary>
    /// Класс для скачивания вложений из писем.
    /// </summary>
    internal class DownloadAttachment
    {
        public void Init()
        {
            using var client = new Pop3Client();

            client.Connect("pop.mail.ru", 995, true);
            client.Authenticate("your_email", "your_password",
                AuthenticationMethod.UsernameAndPassword);
            if (client.Connected)
            {
                var messageCount = client.GetMessageCount();
                var allMessages = new List<Message>(messageCount);

                for (var i = 1; i <= messageCount; i++)
                    allMessages.Add(client.GetMessage(i));

                var dirrectory = Directory.CreateDirectory("c:\\DownloadAttachments");
                foreach (var msg in allMessages)
                {
                    var att = msg.FindAllAttachments();
                    SaveAttachmentRarZip(att, dirrectory);
                }
            }
        }

        /// <summary>
        ///     Сохранить вложения Zip и Rar
        /// </summary>
        /// <param name="attachments">Вложения</param>
        private static void SaveAttachmentRarZip(List<MessagePart> attachments, DirectoryInfo dirrectory)
        {
            foreach (var attachment in attachments)
                if (IsRarOrZip(attachment))
                {
                    attachment.Save(new FileInfo(Path.Combine(dirrectory.FullName, attachment.FileName)));
                    Console.WriteLine($"Сохранен файл: {attachment.FileName}");
                }
        }

        /// <summary>
        ///     Проверка на ZIP или RAR
        /// </summary>
        /// <param name="attachment">Вложенный файл.</param>
        /// <returns>bool</returns>
        private static bool IsRarOrZip(MessagePart attachment)
        {
            if (attachment.FileName.EndsWith(".rar") || attachment.FileName.EndsWith(".zip"))
                return true;

            return false;
        }
    }
}