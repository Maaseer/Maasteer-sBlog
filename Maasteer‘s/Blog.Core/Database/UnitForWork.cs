using Blog.infrastructure.Interface;
using System.Threading.Tasks;

namespace Blog.Core.Database
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
