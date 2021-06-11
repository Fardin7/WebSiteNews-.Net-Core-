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
   public class NewsCategoryService : GenericService<NewsCategory>, INewsCategoryService
    {
        private readonly INewsCategoryRepository _newsCategoryRepository;
        private readonly IRepository<NewsCategory> _repository;
        private readonly IUnitOfWork _unitOfWork;
        public NewsCategoryService(INewsCategoryRepository newsCategoryRepository, IRepository<NewsCategory>  repository) : base(repository)
        {
            this._newsCategoryRepository = newsCategoryRepository;
            this._repository = repository;
            
        }

        //public NewsCategory GetByTitle(string title)
        //{
        //    return _newsCategoryRepository.GetByTitle(title);
        //}

        public IQueryable<IGrouping<string, News>> LastNewsOfNewsCategory(int newstype)
        {
            return _newsCategoryRepository.LastNewsOfNewsCategory(newstype);
        }
    }
}
