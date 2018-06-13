using System.Linq;

namespace InCoreLib.Domain.Enum
{
    public static class Extensions
    {
        public static bool IsNumeric(this string s)
        {
            return s.All(c => char.IsDigit(c) || c == '.');
        }
    }
}
