using System.Linq;
using DAL;
using Model;
namespace Repository.Inerface
{
  public  interface INewsCategoryRepository : IRepository<NewsCategory>
    {

        IQueryable<IGrouping<string, News>> LastNewsOfNewsCategory(int newstype);
    }
}
