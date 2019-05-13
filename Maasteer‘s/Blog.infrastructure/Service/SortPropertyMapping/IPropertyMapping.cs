using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Service.infrastructure.Service
{
    public  interface IPropertyMapping
    {
        //使用字典存储属性映射
        Dictionary<string,List<MappedProperty>> MappingDictionary { get; } 
    }
}
