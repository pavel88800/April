using System;

namespace EnumAttribute
{
    public static class EnumExtension
    {
        /// <summary>
        ///     Получить строку, указанную в атрибуте для значения
        /// </summary>
        /// <param name="value">Значение перечисления</param>
        /// <returns>Значение атрибута</returns>
        public static string ToText(this Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());

            var attributes = (TextAttribute[]) fieldInfo.GetCustomAttributes(typeof(TextAttribute), false);

            if (attributes.Length > 0)
                return attributes[0].Name;

            return value.ToString();
        }
    }
}