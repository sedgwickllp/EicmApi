using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Eicm.Core.Attributes;

namespace Eicm.Core
{
    public static class EnumExtensions
    {
        public static List<EnumValue> GetValues<T>()
        {
            return (from object itemType in Enum.GetValues(typeof(T))
                select new EnumValue()
                {
                    Name = Enum.GetName(typeof(T), itemType),
                    Id = (int) itemType,
                    Active = itemType.GetType().GetTypeInfo().GetDeclaredField(itemType.ToString()).GetCustomAttribute<ActiveAttribute>().Value 
                }).ToList();
        }

        public static string GetEnumDisplayName(this Enum enumType)
        {
            return enumType.GetType().GetMember(enumType.ToString())
                .First()
                .GetCustomAttribute<DisplayNameAttribute>()
                .Value;
                
        }
    }
}
