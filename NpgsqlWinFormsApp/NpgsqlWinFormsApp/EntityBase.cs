using System;

namespace NpgsqlWinFormsApp
{
    public class EntityBase
    {
        public Guid ID { get; set; } = Guid.NewGuid();
    }
}