using System;

namespace EnumAttribute
{
    /// <summary>
    ///     Атрибут Text.
    /// </summary>
    internal class TextAttribute : Attribute
    {
        /// <summary>
        ///     Конструктор.
        /// </summary>
        /// <param name="name">Имя.</param>
        public TextAttribute(string name)
        {
            Name = name;
        }

        /// <summary>
        ///     Имя.
        /// </summary>
        public string Name { get; set; }
    }
}