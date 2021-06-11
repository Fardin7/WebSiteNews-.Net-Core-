using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Service.Interface;
using Repository.Inerface;
using DAL;
namespace Service.Service
{
   public class NewsService:GenericService<News>,INewsService
    {
        private readonly INewsRepository _newsRepository;
        private readonly IRepository<News> _repository;
        private readonly IUnitOfWork _unitOfWork;
        public NewsService(INewsRepository newsRepository, IRepository<News>  repository) : base(repository)
        {
            this._newsRepository = newsRepository;
            this._repository = repository;
            
        }

        public News GetByTitleAndType(string title,int type)
        {
            return _newsRepository.GetByTitleAndType(title,type);
        }

        public List<News> GetTrendingNews()
        {
            return _newsRepository.GetTrendingNews();
        }

        public List<News> ListNewsOfNewsCategoryAndCategory(int newstype, string categoryname, string newscategoryname, int count)

        {
            return _newsRepository.ListNewsOfNewsCategoryAndCategory(newstype, categoryname, newscategoryname,count);

        }

        public List<News> RelatedNewsPagin(int newstype, int categoryname, int newscategoryname, int count, int pagenumber)
        {
            return _newsRepository.RelatedNewsPagin( newstype,  categoryname,  newscategoryname,  count,  pagenumber);

        }
    }
}
