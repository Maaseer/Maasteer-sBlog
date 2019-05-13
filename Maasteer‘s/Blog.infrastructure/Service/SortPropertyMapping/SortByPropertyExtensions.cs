using Blog.Service.infrastructure.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
namespace Blog.Service.infrastructure.SortPropertyMapping
{
    public static class SortByPropertyExtensions
    {
        //为IQueryable添加ApplySort扩展方法-----根据属性字符串排序的实现
        public static IQueryable<T> ApplySort<T>(
            this IQueryable<T> source, string orderBy, IPropertyMapping propertyMapping)
        {
            //判断源数据，若为空，抛出异常
            if (source == null)
            {
                throw new ArgumentException(nameof(source));
            }
            //判断属性映射表，若为空，抛出异常
            if(propertyMapping == null)
            {
                throw new ArgumentException(nameof(propertyMapping));
            }
            //检查属性映射字典，若为空，抛出异常
            var mappingDiction = propertyMapping.MappingDictionary;
            if(mappingDiction == null)
            {
                throw new ArgumentException(nameof(mappingDiction));
            }
            //排序字符串为空，则直接返回源数据
            if (string.IsNullOrWhiteSpace(orderBy))
                return source;

            //将排序字符串根据'，'分词，得到排序关键字数组
            var orderBeforeSplit = orderBy.Split(',');
            //遍历排序关键字数组，对数据进行排序
            foreach (var item in orderBeforeSplit)
            {
                //去除排序关键字首尾的空格
                var orderBeforeTrim = item.Trim();
                //判断是否顺序/倒序排序
                var orderDesc = orderBeforeTrim.EndsWith(" desc");
                //找出第一个空字符的索引
                var firstSpaceIndex = orderBeforeTrim.IndexOf(" ", StringComparison.Ordinal);
                //若有空字符，则删除该空字符
                var propertyName = firstSpaceIndex == -1 ? orderBeforeTrim : orderBeforeTrim.Remove(firstSpaceIndex);
                //如果该属性为空，则进行下一次循环
                if (string.IsNullOrEmpty(propertyName))
                    continue;
                
                
                //通过反射获得该属性是否存在于字典中，并建立新变量存储属性组
                if (!mappingDiction.TryGetValue(propertyName, out List<MappedProperty> mappedProperties))
                    throw new ArgumentException($"key mapping for {propertyName} is missing");
                //如果属性链表为空，抛出异常
                if (mappedProperties == null)
                    throw new ArgumentException(propertyName);

                //逆转属性链表
                mappedProperties.Reverse();
                //遍历属性链表
                foreach (var destinationProperty in mappedProperties)
                {
                    //正序/逆序
                    if (destinationProperty.Order)
                    {
                        orderDesc = !orderDesc;
                    }
                    //将源数据进行排序
                    source = source.OrderBy(destinationProperty.Name + (orderDesc ? " descending" : " ascending"));
                }
            }
            //返回源数据
            return source;
        }
    }

}
