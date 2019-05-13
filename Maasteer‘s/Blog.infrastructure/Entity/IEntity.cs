using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.infrastructure.Model
{
   public abstract class IEntity
    {
        public int Id { set; get; }
    }
}
