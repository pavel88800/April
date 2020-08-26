using System;
using System.Linq;

namespace EnumAttribute
{
    class Program
    {
        static void Main(string[] args)
        {
            var enumList = Enum.GetValues(typeof(NpgsqlType)).OfType<NpgsqlType>().ToList();
            foreach (var _enum in enumList)
            {
                Console.WriteLine(_enum.ToText());
            }
        }
    }
}
