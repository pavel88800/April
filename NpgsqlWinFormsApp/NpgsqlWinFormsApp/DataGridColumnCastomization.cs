using System;

namespace NpgsqlWinFormsApp
{
    public class DataGridColumnCastomization
        : EntityBase
    {
        public string Name { get; set; }
        public int Width { get; set; }
        public bool Visible { get; set; }
        public int Order { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}