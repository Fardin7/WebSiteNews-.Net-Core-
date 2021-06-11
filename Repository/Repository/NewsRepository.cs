using System;
using System.Collections.Generic;
using System.Linq;
using Model;
using DAL;
using Repository.Inerface;

namespace Repository.Repository
{
   public class NewsRepository : GenericRepository<News>, INewsRepository
    {

        public NewsRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public News GetByTitleAndType(string title,int type)
        {
            return dbSet.Where(q => q.Title == title && q.NewsType==type && q.IsActive && q.PublishDate <= DateTime.Now).FirstOrDefault();
        }
        public List<News> GetTrendingNews()
        {
            var trendcount = Get(a => a.IsTrend).Count();
            return trendcount == 1 ? Get(a => a.IsTrend).ToList() : Get().ToList() ;
        }

        public List<News> ListNewsOfNewsCategoryAndCategory(int newstype, string categoryname, string newscategoryname,int count)
        {
            if (categoryname!=null && newscategoryname!=null)
            { 
                return dbSet.Where((q => q.NewsSubCategory.NewsCategory.Title == newscategoryname && q.Subcategory.Title == categoryname && q.NewsType==newstype && q.IsActive && q.PublishDate <= DateTime.Now)).OrderByDescending(q=>q.Id).Take(count).ToList();
            }
            return dbSet.Where(q => q.NewsSubCategory.NewsCategory.Title == newscategoryname || q.Subcategory.Category.Title == categoryname ).Where(q=>q.NewsType == newstype && q.IsActive && q.PublishDate <= DateTime.Now).OrderByDescending(q => q.Id).Take(count).ToList();
        }

        public List<News> RelatedNewsPagin(int newstype, int categoryname, int newscategoryname, int count,int pagenumber)
        {
            var newsofallpages = count * pagenumber;
            var skipnews = (pagenumber - 1) * count;
            if (categoryname != 0 && newscategoryname != 0 && pagenumber>0)
            {
               
                var countall = dbSet.Where((q => q.NewsSubCategory.NewsCategory.Id == newscategoryname && q.Subcategory.Id == categoryname && q.NewsType == newstype && q.IsActive && q.PublishDate<=DateTime.Now)).Count();
                if (newsofallpages > countall)
                {

                    return dbSet.Where((q => q.NewsSubCategory.NewsCategory.Id == newscategoryname && q.Subcategory.Id == categoryname && q.NewsType == newstype && q.IsActive && q.PublishDate <= DateTime.Now)).OrderBy(q => q.Id).Take(count).ToList();

                   
                }
                else
                {
                    return dbSet.Where((q => q.NewsSubCategory.NewsCategory.Id == newscategoryname && q.Subcategory.Id == categoryname && q.NewsType == newstype && q.IsActive && q.PublishDate <= DateTime.Now)).OrderByDescending(q => q.Id).Take(newsofallpages).Skip(skipnews).ToList();

                }
               
               
            }
            else
            {
                return dbSet.Where((q => q.NewsSubCategory.NewsCategory.Id == newscategoryname || q.Subcategory.CategoryId == categoryname)).Where(q=>q.NewsType == newstype && q.IsActive && q.PublishDate <= DateTime.Now).OrderByDescending(q => q.Id).Take(newsofallpages).Skip(skipnews).ToList();

            }

        }
    }
}
