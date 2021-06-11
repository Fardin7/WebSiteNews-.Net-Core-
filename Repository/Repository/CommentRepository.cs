using Model;
using DAL;
using Repository.Inerface;
using Microsoft.EntityFrameworkCore;


namespace Repository.Repository
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        private DbContext _context;
        // internal DbSet<Article> dbSet;
        public CommentRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._context = unitOfWork.DBContext;

        }


    }
}
