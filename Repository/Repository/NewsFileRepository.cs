using Model;
using DAL;
using Repository.Inerface;
using Microsoft.EntityFrameworkCore;


namespace Repository.Repository
{
   public class NewsFileRepository : GenericRepository<NewsFile>, INewsFileRepository
    {
        private DbContext _context;
        public NewsFileRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._context = unitOfWork.DBContext;
        }
    }
}
