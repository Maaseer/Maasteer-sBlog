using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;

//资源塑形扩展方法----扩展了IEnumerable<ExpandoObject>
namespace Blog.infrastructure.Service.ResourceShaping
{
    public static class ResourceShapingEnumerableExtensions
    {
        public static IEnumerable<ExpandoObject> ToDynamicIEnumerable<TSource>(this IEnumerable<TSource> sources, string fields = null)
        {
            if(sources == null)
            {
                throw new ArgumentException(nameof(sources));
            }
            //属性列表
            var PropertyList = new List<PropertyInfo>();
            //返回资源列表
            var ExpandoList = new List<ExpandoObject>();

            //若塑形字符串为空，则将所有属性添加进返回资源中
            if (string.IsNullOrWhiteSpace(fields))
            {
                PropertyList.AddRange(typeof(TSource).GetProperties(BindingFlags.Public| BindingFlags.Instance| BindingFlags.IgnoreCase));
            }
            else
            {
                //保证返回的资源中有id
                PropertyList.Add(typeof(TSource).GetProperty("Id", BindingFlags.Public | BindingFlags.IgnoreCase | BindingFlags.Instance));

                //分词
                var fieldsRange = fields.Split(',').ToList();
                foreach (var item in fieldsRange)
                {
                    //去首尾空格
                    item.Trim();

                    //尝试从源对象提取属性Info
                    //若为空或者id，跳过
                    if (string.IsNullOrEmpty(item) && item.ToLower()=="id")
                        continue;
                    var propertyInfo = typeof(TSource).GetProperty(item, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);//BindingFlags.IgnoreCase 忽略大小写
                    if (propertyInfo == null)
                    {
                        throw new Exception($"Property {item} is not in {nameof(TSource)}");
                    }
                    //将属性Info添加至属性Info列表中
                    PropertyList.Add(propertyInfo);
                }
            }
            //遍历每个源对象，重塑
            foreach (var source in sources)
            {
                var expandoObject = new ExpandoObject();
                foreach (var item in PropertyList)
                {
                    expandoObject.TryAdd(item.Name, item.GetValue(source));
                }
                ExpandoList.Add(expandoObject);
            }
            return ExpandoList;
        }
    }
}
