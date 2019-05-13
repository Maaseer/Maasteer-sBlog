using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core.Database.Pagination
{
    //含有分页属性+数据List的类
   public class PaginatedList<T> : List<T> where T : class
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }


        private int _totalItemsCount;//这是一个成员变量，private表示是私有的，外部不可访问



        public int TotalItemsCount
        {
            get => _totalItemsCount; //当外部访问“属性”TotalItemsCount时，返回_totalItemsCount的值
            set => _totalItemsCount = (value >= 0 ? value : 0);//当外部为“属性”TotalItemsCount赋值时，将_totalItemsCount赋值为value，value就是外部为“属性”ID所赋的值
        }

        //decimal是高精度浮点数   Ceiling向上取整需要decimal类型的数据
        //类似的 Round 四舍五入 Floor 向下取整
        public int PageCount => (int)Math.Ceiling((decimal)(_totalItemsCount / PageSize));
        public bool HasPrevious => PageIndex > 0;
        public bool HasNext => PageIndex < PageCount - 1;
        public PaginatedList(int pageSize, int pageIndex, int totalItemsCount, IEnumerable<T> Data)
        {
            PageSize = pageSize;
            PageIndex = pageIndex;
            TotalItemsCount = totalItemsCount;
            AddRange(Data);
        }

    }
}
