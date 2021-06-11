using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DAL
{
  public  interface IUnitOfWork
    {

        DbContext DBContext { get;  }
        Task<int> CompleteAsync();
        int Complete();
        
       
    }
}
