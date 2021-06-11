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
   public class NewsFileService : GenericService<NewsFile>, INewsFileService
    {
        private readonly INewsFileRepository _newsFileRepository;
        private readonly IRepository<NewsFile> _repository;
        private readonly IUnitOfWork _unitOfWork;
        public NewsFileService(INewsFileRepository newsFileRepository, IRepository<NewsFile>  repository) : base(repository)
        {
            this._newsFileRepository = newsFileRepository;
            this._repository = repository;
            
        }



       
    }
}
