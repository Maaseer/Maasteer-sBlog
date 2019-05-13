using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.infrastructure.Service.TypeHelp
{
    public interface ITypehelper
    {
        bool TypeHasProperties<T>(string fields);
    }
}
