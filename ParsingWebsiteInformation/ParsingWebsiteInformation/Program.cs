using System;
using ExceptionCatching;
using ParsingWebsiteInformation.DB;
using ParsingWebsiteInformation.Parsing;

namespace ParsingWebsiteInformation
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ClientException.Process();

            WorkInDb.CreateDbAndTable();
            Console.WriteLine("Press Esc to exit");
            do
            {
                Console.WriteLine("Введите урл:");
                var url = Console.ReadLine();
                var productAttr = ParseHtml.GetAttr(url);

                if (productAttr != null)
                {
                    WorkInDb.InsertData(productAttr);
                    WorkInDb.SelectData();
                }
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}