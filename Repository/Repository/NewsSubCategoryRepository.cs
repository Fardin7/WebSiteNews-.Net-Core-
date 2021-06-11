using System.Linq;
using Model;
using DAL;
using Repository.Inerface;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repository
{
   public class NewsSubCategoryRepository : GenericRepository<NewsSubCategory>, INewsSubCategoryRepository
    {
        private DbContext _context;
      // internal DbSet<Article> dbSet;
        public NewsSubCategoryRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._context = unitOfWork.DBContext;

        }

        public NewsSubCategory GetByTitle(string title)
        {
            return _context.Set<NewsSubCategory>().Where(q => q.Title == title).FirstOrDefault();
        }

      
    }
}
