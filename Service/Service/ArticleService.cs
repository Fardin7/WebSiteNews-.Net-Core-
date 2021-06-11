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
   public class ArticleService:GenericService<Article>,IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IRepository<Article> _repository;
        private readonly IUnitOfWork _unitOfWork;
        public ArticleService(IArticleRepository articleRepository, IRepository<Article>  repository) : base(repository)
        {
            this._articleRepository = articleRepository;
            this._repository = repository;
            
        }

        public Article GetByTitle(string title)
        {
            return _articleRepository.GetByTitle(title);
        }

    }
}
