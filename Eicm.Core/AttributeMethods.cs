using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Eicm.Core.Attributes;

namespace Eicm.Core
{
    public static class AttributeMethods
    {
        public static TR GetAttributeValue<T, TR>(IConvertible @enum)
        {
            var attributeValue = default(TR);

            if (@enum == null) return attributeValue;

            var fi = @enum.GetType().GetField(@enum.ToString(CultureInfo.InvariantCulture));
            if (fi == null) return attributeValue;

            var attributes = fi.GetCustomAttributes(typeof(T), false) as T[];
            if (attributes == null || attributes.Length <= 0) return attributeValue;

            var attribute = attributes[0] as IAttribute<TR>;
            if (attribute != null)
            {

                attributeValue = attribute.Value;
            }

            return attributeValue;
        }

        public static T GetByDisplayed<T>(string value)
        {
            var type = typeof(T);
            //if (!type.IsEnum)
            //{
            //    throw new ArgumentException();
            //}

            var fields = type.GetFields();
            var field =
                fields
                    .SelectMany(f => f.GetCustomAttributes(typeof(DisplayNameAttribute), false), (f, a) => new { Field = f, Att = a })
                    .SingleOrDefault(a => ((DisplayNameAttribute)a.Att).Value == value);

            return (T) field?.Field.GetRawConstantValue();
        }

        public static T GetAttribute<T>(this Enum enumValue)
            where T : Attribute
        {
            return enumValue
                .GetType()
                .GetTypeInfo()
                .GetDeclaredField(enumValue.ToString())
                .GetCustomAttribute<T>();
        }
    }
}
