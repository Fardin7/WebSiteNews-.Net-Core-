using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        public DbContext dbcontext;
        public UnitOfWork(Context dbContext)
        {
            if (dbcontext==null)
            {
                dbcontext = dbContext;

            }

        }
        public DbContext DBContext
        {
            get
            {
                return dbcontext;
            }
        }

        public int Complete()
        {
            return dbcontext.SaveChanges();
        }

        public async Task<int> CompleteAsync()
        {
            return await dbcontext.SaveChangesAsync();
        }
        public void Dispose()
        {
            if (dbcontext != null)
                dbcontext.Dispose();
        }
    }
}
