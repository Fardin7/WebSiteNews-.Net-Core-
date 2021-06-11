using System;
using System.Collections.Generic;
using System.Linq;
using Model;
using DAL;
using Repository.Inerface;
using Microsoft.EntityFrameworkCore;
namespace Repository.Repository
{
   public class ArticleRepository : GenericRepository<Article>, IArticleRepository 
    {
        private DbContext _context;
      // internal DbSet<Article> dbSet;
        public ArticleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._context = unitOfWork.DBContext;
        }

        public Article GetByTitle(string title)
        {
          return  _context.Set<Article>().Where(q => q.Title == title).FirstOrDefault();
        }
    }
}
