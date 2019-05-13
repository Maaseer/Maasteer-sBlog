using System.Linq;
using System.Reflection;

namespace Blog.infrastructure.Service.TypeHelp
{
    public class TypeHelper : ITypehelper
    {
        public bool TypeHasProperties<T>(string fields)
        {
            if (string.IsNullOrWhiteSpace(fields))
                return true;

            PropertyInfo[] propertyList = typeof(T).GetProperties(BindingFlags.IgnoreCase
                                                                  | BindingFlags.Public
                                                                  | BindingFlags.Instance);
            var propertyNameList = fields.Split(',').ToList();
            foreach (var item in propertyNameList)
            {
                item.Trim();
                if (string.IsNullOrEmpty(item))
                    continue;
                if (PaddingPropertyName<T>(item) == null)
                    return false;
            }
            return true;
        }

        private static PropertyInfo PaddingPropertyName<T>(string item)
        {
            return typeof(T).GetProperty(item, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
        }
    }
}
