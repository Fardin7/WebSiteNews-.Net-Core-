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
   public class SubCategoryService:GenericService<Subcategory>,ISubCategoryService
    {
        private readonly ISubCategoryRepository _newsSubCategoryRepository;
        private readonly IRepository<Subcategory> _repository;
        private readonly IUnitOfWork _unitOfWork;
        public SubCategoryService(ISubCategoryRepository _newsSubCategoryRepository, IRepository<Subcategory>  repository) : base(repository)
        {
            this._newsSubCategoryRepository = _newsSubCategoryRepository;
            this._repository = repository;
            
        }

        public Subcategory GetByTitle(string title)
        {
            return _newsSubCategoryRepository.GetByTitle(title);
        }

       
    }
}
