using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;

//资源塑形扩展方法----扩展了ExpandoObject  
//过程与IEnumerable扩展方法同理，略
namespace Blog.infrastructure.Service.ResourceShaping
{
    public static class  ResourceShapingSingleExtensions
    {
       public static ExpandoObject ToDynamic<TSource>(this TSource source,string fields = null)
        {
            if (source == null)
                throw new ArithmeticException(nameof(TSource));
            var PropertyList = new List<PropertyInfo>();
            var expando = new ExpandoObject();
            if (string.IsNullOrWhiteSpace(fields))
            {
                PropertyList.AddRange(typeof(TSource).GetProperties(BindingFlags.Public | BindingFlags.IgnoreCase | BindingFlags.Instance));                
            }
            else
            {
                //保证返回的资源中有id
                PropertyList.Add(typeof(TSource).GetProperty("Id", BindingFlags.Public | BindingFlags.IgnoreCase | BindingFlags.Instance));
                var propertyList = fields.Split(',').ToList();
                foreach (var item in propertyList)
                {
                    item.Trim();
                    //若为空或者id，跳过
                    if (string.IsNullOrEmpty(item) && item.ToLower() == "id")
                        continue;
                    var propertyInfo = typeof(TSource).GetProperty(item, BindingFlags.Public|BindingFlags.IgnoreCase | BindingFlags.Instance);
                    if (propertyInfo == null)
                        throw new Exception($"Property {item} is not in {nameof(TSource)}");
                    PropertyList.Add(propertyInfo);
                }
            }
            foreach (var item in PropertyList)
            {
                expando.TryAdd(item.Name, item.GetValue(source));
            }
            return expando;

        }
    }
}
