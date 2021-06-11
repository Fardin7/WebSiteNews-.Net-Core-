using System.Linq;
using Model;
using DAL;
using Repository.Inerface;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private DbContext _context;
        // internal DbSet<Article> dbSet;
        public CategoryRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._context = unitOfWork.DBContext;




        }

        public Category GetByTitle(string title)
        {
            return _context.Set<Category>().Where(q => q.Title == title).FirstOrDefault();
        }

        public int GetCount()
        {

            var b = dbSet.Count();
            return b;

        }
        public IQueryable<IGrouping<string, News>> LastNewsOfCategory(int newstype)
        {
            var newsofcategory = (from category in dbSet
                                  join subcategory in _context.Set<Subcategory>()
                                  on category.Id equals subcategory.CategoryId
                                  join news in _context.Set<News>()
                                  on subcategory.Id equals news.SubcategoryId into categorysubcategorynews
                                  from csn in categorysubcategorynews
                                  where csn.NewsType == newstype && csn.IsActive
                                  orderby csn.PublishDate descending
                                  group csn by category.Title
                                 );
            return newsofcategory;
        }


    }
}
