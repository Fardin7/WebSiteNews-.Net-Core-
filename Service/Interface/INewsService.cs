using System.Collections.Generic;
using Model;
namespace Service.Interface
{
  public  interface INewsService:Iservice<News>
    {
        News GetByTitleAndType(string title,int type);
        List<News> ListNewsOfNewsCategoryAndCategory(int newstype, string categoryname, string newscategoryname, int count);
        List<News> RelatedNewsPagin(int newstype, int categoryname, int newscategoryname, int count, int pagenumber);
        List<News> GetTrendingNews();
    }
}
