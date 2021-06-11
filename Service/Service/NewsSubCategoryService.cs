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
   public class NewsSubCategoryService : GenericService<NewsSubCategory>, INewsSubCategoryService
    {
        private readonly INewsSubCategoryRepository _newsSubCategoryRepository;
        private readonly IRepository<NewsSubCategory> _repository;
        private readonly IUnitOfWork _unitOfWork;
        public NewsSubCategoryService(INewsSubCategoryRepository _newsSubCategoryRepository, IRepository<NewsSubCategory>  repository) : base(repository)
        {
            this._newsSubCategoryRepository = _newsSubCategoryRepository;
            this._repository = repository;
            
        }

        public NewsSubCategory GetByTitle(string title)
        {
            return _newsSubCategoryRepository.GetByTitle(title);
        }

       
    }
}
