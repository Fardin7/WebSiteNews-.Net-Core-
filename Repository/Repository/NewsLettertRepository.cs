using Model;
using DAL;
using Repository.Inerface;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repository
{
    public class NewsLetterRepository : GenericRepository<NewsLetter>, INewsLetterRepository
    {
        private DbContext _context;
        // internal DbSet<Article> dbSet;
        public NewsLetterRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._context = unitOfWork.DBContext;

        }


    }
}
