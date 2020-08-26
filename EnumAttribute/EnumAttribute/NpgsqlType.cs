namespace EnumAttribute
{
    internal enum NpgsqlType
    {
        [Text("anyarray")] Array = -2147483648,
        Unknown = 0,
        [Text("int8")] Bigint = 1,
        [Text("bool")] Boolean = 2,
        [Text("box")] Box = 3,
        [Text("bytea")] Bytea = 4,
        [Text("circle")] Circle = 5
    }
}