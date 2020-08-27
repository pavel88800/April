using System.Data;
using NpgsqlTypes;

namespace NpgsqlWinFormsApp.Interfaces
{
    internal interface IPgConnectionInterfaces
    {
        /// <summary>
        ///     Получение параметров из запроса
        /// </summary>
        /// <returns>bool</returns>
        bool DeriveParameters();

        /// <summary>
        ///     Открытие соединения с БД
        /// </summary>
        /// <returns>bool</returns>
        bool OpenConnection();

        /// <summary>
        ///     Закрытие соединения с БД
        /// </summary>
        /// <returns>bool</returns>
        bool CloseConnection();

        /// <summary>
        ///     Присвоение параметру parameterName значения parameterValue и типа type
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="parameterValue"></param>
        /// <param name="type"></param>
        /// <returns>bool</returns>
        bool Add(string parameterName, object parameterValue, NpgsqlDbType type);

        /// <summary>
        ///     Начало транзакции
        /// </summary>
        /// <returns>bool</returns>
        bool BeginTransaction();

        /// <summary>
        ///     Успешное завершение транзакции
        /// </summary>
        /// <returns>bool</returns>
        bool CommitTransaction();

        /// <summary>
        ///     Отмена изменений в указанной транзакции
        /// </summary>
        /// <returns>bool</returns>
        bool RollbackTransaction();

        /// <summary>
        ///     Выполнение запроса без получения результата в ответе
        /// </summary>
        /// <returns>bool</returns>
        bool ExecuteNonQuery();

        /// <summary>
        ///     Заполнение DataTable табличными данными из запроса
        /// </summary>
        /// <returns>
        ///     <see cref="DataTable" />
        /// </returns>
        DataTable FillData();
    }
}