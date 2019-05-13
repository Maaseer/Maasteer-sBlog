using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.UnitOfWork
{
   public interface IUnitForWork
    {
        //声明工作单元的接口 
        Task<bool> SaveAsync();
    }
}
