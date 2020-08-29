using System.Collections.Generic;

namespace NpgsqlWinFormsApp
{
    public class User
        : EntityBase
    {
        public string Name { get; set; }

        public ICollection<DataGridColumnCastomization> DataGridCastomizations { get; set; }
    }
}