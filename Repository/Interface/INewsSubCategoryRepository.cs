using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
namespace Repository.Inerface
{
  public  interface INewsSubCategoryRepository : IRepository<NewsSubCategory>
    {
        NewsSubCategory GetByTitle(string title);
    }
}
