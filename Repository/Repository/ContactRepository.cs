using Model;
using DAL;
using Repository.Inerface;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repository
{
    public class ContactRepository : GenericRepository<Contact>, IContactRepository
    {
        private DbContext _context;
        // internal DbSet<Article> dbSet;
        public ContactRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._context = unitOfWork.DBContext;




        }


    }
}
