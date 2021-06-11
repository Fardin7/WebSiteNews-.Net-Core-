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
   public class NewsLetterService : GenericService<NewsLetter>, INewsLetterService
    {
        private readonly INewsLetterRepository _newsletterRepository;
        private readonly IRepository<NewsLetter> _repository;
       
        public NewsLetterService(INewsLetterRepository newsletterRepository, IRepository<NewsLetter>  repository) : base(repository)
        {
            this._newsletterRepository = newsletterRepository;
            this._repository = repository;
            
        }

       
    }
}
