using System;
using System.Data;
using System.Data.SQLite;
using ParsingWebsiteInformation.Parsing;

namespace ParsingWebsiteInformation.DB
{
    /// <summary>
    ///     Класс для сохранения продуктов в БД.
    /// </summary>
    internal class WorkInDb
    {
        /// <summary>
        ///     Вставить в БД полученные значения.
        /// </summary>
        /// <param name="productAttr">Атрибуты продукта.</param>
        public static void InsertData(ProductDto productAttr)
        {
            using (var connection = new SQLiteConnection("Data Source=CompanyWorkers.sqlite;Version=3;"))
            {
                connection.ConnectionString = "Data Source = CompanyWorkers.sqlite";
                connection.Open();

                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText =
                        string.Format(
                            "INSERT INTO productInfo (productName, normalPrice, discount, manufacturer) VALUES( \"{0}\", \"{1}\", \"{2}\", \"{3}\");",
                            productAttr.ProductName, productAttr.NormalPrice, productAttr.Discount,
                            productAttr.Manufacturer);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        /// <summary>
        ///     Получить данные из БД
        /// </summary>
        public static void SelectData()
        {
            using (var connection = new SQLiteConnection("Data Source=CompanyWorkers.sqlite;Version=3;"))
            {
                connection.ConnectionString = "Data Source = CompanyWorkers.sqlite";
                connection.Open();

                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = "SELECT * FROM productInfo";
                    var reader = command.ExecuteReader();
                    var count = 1;

                    Console.WriteLine("№ | Наименование товара | Цена без скидки | Цена со скидкой | Производитель ");
                    while (reader.Read())
                    {
                        var myreader = string.Empty;
                        ;
                        if (!reader.IsDBNull(1))
                            myreader = string.Format("{0} | {1} | {2} | {3} | {4}", count, reader.GetString(1),
                                reader.GetString(2), reader.GetString(3), reader.GetString(4));
                        Console.WriteLine(myreader);
                        count++;
                    }
                }

                connection.Close();
            }
        }

        /// <summary>
        ///     Создать БД и таблицу.
        /// </summary>
        public static void CreateDbAndTable()
        {
            var baseName = "CompanyWorkers.sqlite";

            SQLiteConnection.CreateFile(baseName);

            using (var connection = new SQLiteConnection("Data Source=CompanyWorkers.sqlite;Version=3;"))
            {
                connection.ConnectionString = "Data Source = " + baseName;
                connection.Open();

                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = @"CREATE TABLE [productInfo] (
                    [id] integer PRIMARY KEY AUTOINCREMENT NOT NULL,
                    [productName] varchar(100) NOT NULL,
                    [normalPrice] varchar(100) NOT NULL,
                    [discount] varchar(100) NOT NULL,
                    [manufacturer] varchar(100) NOT NULL
                    );";
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
    }
}