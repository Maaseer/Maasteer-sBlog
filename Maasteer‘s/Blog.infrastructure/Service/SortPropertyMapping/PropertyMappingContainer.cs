using System;
using System.Collections.Generic;
using System.Linq;
using Blog.infrastructure.Model;

//排序功能-验证输入的排序字符串中，属性是否存在
namespace Blog.Service.infrastructure.Service
{
    public class PropertyMappingContainer : IPropertyMappingContainer
    {
        //存储容器中的属性映射
        protected readonly IList<IPropertyMapping> propertyMappings = new List<IPropertyMapping>();
        public void Register<T>() where T : IPropertyMapping, new()
        {
            //如果该属性映射在该容器中未被注册
            if(propertyMappings.All(x=>x.GetType() != typeof(T)))
            {
                //则注册该属性映射
                propertyMappings.Add(new T());
            }
        }
        //建立属性字典
        public IPropertyMapping Resolve<TSource, TDestination>() where TDestination : IEntity
        {
            //找到符合源类和目标类的属性映射
            var matchingMapping = propertyMappings.OfType<PropertyMapping<TSource, TDestination>>().ToList();
            //若找到属性映射数量为1，则返回该属性映射
            if (matchingMapping.Count == 1)
                return matchingMapping.First();
            //若找到属性映射数量不为1，则抛出异常
            throw new Exception($"Cannot find property mapping instance for <{typeof(TSource)},{typeof(TDestination)}>");
        }

        //验证输入的排序字符串中，所有的属性在Entity中是否有与之对应的属性
        public bool ValidateMappingExistsFor<TSource, TDestination>(string fields) where TDestination : IEntity
        {
            //若排序字符串为空，则字符串语法正确，校验通过
            if (string.IsNullOrWhiteSpace(fields))
                return true;

            //建立源属性与Entity属性的映射字典
            var propertyMapping = Resolve<TSource, TDestination>();
            //切分字符串，获得字符串数组（属性名）
            var fieldsAfterSpilt = fields.Split(',');

            //遍历字符串数组，检验是否有非法属性
            foreach (var item in fieldsAfterSpilt)
            {
                //去掉字符串首尾空格
                var trimField = item.Trim();
                //若字符串中有空格，则将其索引找出
                var indexOfFirstSpace = trimField.IndexOf(" ", StringComparison.Ordinal);
                //去除空格
                var propertyName = indexOfFirstSpace == -1 ? trimField : trimField.Remove(indexOfFirstSpace);
                //若属性名为空，则是合法属性，继续循环
                if (string.IsNullOrWhiteSpace(propertyName))
                    continue;
                //若属性不存在属性字典中，则为非法属性
                if (!propertyMapping.MappingDictionary.ContainsKey(propertyName))
                    return false;
               
            }
            //若所有属性都为合法属性，则整体校验通过
            return true;
        }
    }
}
