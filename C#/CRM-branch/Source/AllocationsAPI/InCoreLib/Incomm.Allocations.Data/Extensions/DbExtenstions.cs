using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Incommunities.Logistics.Data.Extensions
{
    public static class IEnumerableExtensions
    {
        public static DataTable AsDataTable<T>(this IEnumerable<T> data)
        {
            var properties = (typeof(T)).GetProperties().Where(p => p.GetAccessors()[0].IsVirtual == false).ToArray();
            var table = new DataTable();
            foreach (var prop in properties)
            {
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }
            foreach (var item in data)
            {
                var row = table.NewRow();
                foreach (var prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }
                table.Rows.Add(row);
            }
            return table;
        }
    }
}
