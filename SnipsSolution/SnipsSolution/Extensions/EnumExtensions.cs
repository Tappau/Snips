using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SnipsSolution.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Return the [Description] value if set, if not returns the value of the enum.
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum enumType)
        {
            var descriptionAttribute = enumType.GetType().GetField(enumType.ToString())
                ?.GetCustomAttributes(typeof(DescriptionAttribute), false)
                .FirstOrDefault() as DescriptionAttribute;

            return descriptionAttribute != null
                ? descriptionAttribute.Description
                : Enum.GetName(enumType.GetType(), enumType);
        }

        /// <summary>
        /// Return the DisplayName value if set, if not returns the value of the enum.
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static string GetDisplayName(this Enum enumType)
        {
            var displayAttrib = enumType.GetType()
                .GetField(enumType.ToString())?
                .GetCustomAttributes(typeof(DisplayNameAttribute), false)
                .FirstOrDefault() as DisplayNameAttribute;

            return displayAttrib != null
                ? displayAttrib.DisplayName
                : Enum.GetName(enumType.GetType(), enumType);
        }
    }
}