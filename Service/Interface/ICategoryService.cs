using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace Service.Interface
{
  public  interface ICategoryService:Iservice<Category>
    {
         IQueryable<IGrouping<string, News>> LastNewsOfCategory(int newstype);
       // Category GetByTitle(string title);
    }
}
