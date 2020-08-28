using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using Newtonsoft.Json;

namespace NpgsqlWinFormsApp
{
    /// <summary>
    ///     Конвертация из DataTable  в Json и обратно
    /// </summary>
    internal class DataTableJsonConverter
    {
        /// <summary>
        ///     Конвертация в Json
        /// </summary>
        /// <param name="dataTable">DataTable</param>
        /// <returns>string(json)</returns>
        public string ConvertToJson(DataTable dataTable)
        {
            var result = new List<dynamic>();
            foreach (DataRow row in dataTable.Rows)
            {
                dynamic dyn = new ExpandoObject();
                foreach (DataColumn column in dataTable.Columns)
                {
                    var dic = (IDictionary<string, object>) dyn;
                    dic[column.ColumnName] = row[column];
                }

                result.Add(dyn);
            }

            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        ///     Конвертация из Json в DataTable
        /// </summary>
        /// <param name="json">string(json)</param>
        /// <returns>DataTable</returns>
        public DataTable ConvertToDataTable(string json)
        {
            var dataTable = (DataTable) JsonConvert.DeserializeObject(json, typeof(DataTable));
            return dataTable;
        }
    }
}