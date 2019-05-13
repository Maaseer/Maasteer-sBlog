using Blog.infrastructure.Entity;
using System.Threading.Tasks;

namespace Blog.Core.UnitOfWork
{
    public class UnitForWork : IUnitForWork
    {
        public UnitForWork(MyDbContext myDbContext)
        {
            MyDbContext = myDbContext;
        }

        public MyDbContext MyDbContext { get; }

        public async Task<bool> SaveAsync()
        {
            return await MyDbContext.SaveChangesAsync() > 0;
        }
    }
}
