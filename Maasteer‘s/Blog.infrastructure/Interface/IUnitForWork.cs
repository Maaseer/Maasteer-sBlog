using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.infrastructure.Interface
{
   public interface IUnitForWork
    {
        Task<bool> SaveAsync();
    }
}
