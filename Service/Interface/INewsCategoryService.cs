using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace Service.Interface
{
  public  interface INewsCategoryService:Iservice<NewsCategory>
    {

       // NewsCategory GetByTitle(string title);
        IQueryable<IGrouping<string, News>> LastNewsOfNewsCategory(int newstype);
    }
}
