
using System.Linq;
using Model;
using DAL;
using Repository.Inerface;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repository
{
    public class NewsCategoryRepository : GenericRepository<NewsCategory>, INewsCategoryRepository
    {
        private DbContext _context;
        // internal DbSet<Article> dbSet;
        public NewsCategoryRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._context = unitOfWork.DBContext;
        }
        public IQueryable<IGrouping<string,News>> LastNewsOfNewsCategory( int newstype)
        {
            var newsofcategory = (from newscategory in dbSet
                                  join newssubcategory in _context.Set<NewsSubCategory>()
                                  on newscategory.Id equals newssubcategory.NewsCategoryId
                                  join news in _context.Set<News>()
                                  on newssubcategory.Id equals news.NewsSubcategoryId into categorysubcategorynews
                                  from csn in categorysubcategorynews
                                  where csn.NewsType==newstype && csn.IsActive
                                  orderby csn.PublishDate descending
                                  group csn by newscategory.Title
                                 );
                               ;
           

            return newsofcategory;
        }
    }
}
