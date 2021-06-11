using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace Service.Interface
{
  public  interface INewsSubCategoryService : Iservice<NewsSubCategory>
    {
    
        NewsSubCategory GetByTitle(string title);
    }
}
