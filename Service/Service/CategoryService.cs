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
   public class CategoryService:GenericService<Category>,ICategoryService
    {
        private readonly ICategoryRepository _newsCategoryRepository;
        private readonly IRepository<Category> _repository;
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(ICategoryRepository newsCategoryRepository, IRepository<Category>  repository) : base(repository)
        {
            this._newsCategoryRepository = newsCategoryRepository;
            this._repository = repository;
            
        }

        //public Category GetByTitle(string title)
        //{
        //    return _newsCategoryRepository.GetByTitle(title);
        //}

        public IQueryable<IGrouping<string, News>> LastNewsOfCategory(int newstype)
        {
            return _newsCategoryRepository.LastNewsOfCategory(newstype);
        }
    }
}
