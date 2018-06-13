using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace InCoreLib.Domain.Enum
{
    public static class EnumExtensions
    {
        public static string GetAttribute<TEnum>(this System.Enum value) where TEnum : EnumValueAttribute
        {
            if (value.GetType().GetField(value.ToString()) == null) return string.Empty;
            var attributes =
                (TEnum[])value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(TEnum), false);
            return attributes.Length > 0 ? attributes[0].Value : string.Empty;
        }
    }

    public class Enums
    {
        public static IDictionary<string, string> GetDescriptions<TEnum>()
        {
            return typeof(TEnum).GetMembers(BindingFlags.Static | BindingFlags.Public)
                .ToList()
                .Select(m => new
                {
                    Name = m.Name,
                    Description = m.GetCustomAttributes(typeof(DescriptionAttribute), true)
                        .Cast<DescriptionAttribute>()
                        .SingleOrDefault()
                })
                .ToDictionary(a => a.Name, a => a.Description == null ? a.Name : a.Description.Description);
        }
    }

    public abstract class EnumValueAttribute : Attribute
    {
        protected EnumValueAttribute(string value)
        {
            Value = value;
        }

        public string Value { get; set; }
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class DisplayClassAttribute : EnumValueAttribute
    {
        public DisplayClassAttribute(string value)
            : base(value)
        {
        }
    }
}
