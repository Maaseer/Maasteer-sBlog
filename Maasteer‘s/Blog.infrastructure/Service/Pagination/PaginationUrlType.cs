using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core.Database.Pagination
{
    //表示 前一页/当前页/后一页 的枚举项
    public enum PaginationUrlType
    {
        CurrentPage,
        PreviousPage,
        NextPage
    }
}
