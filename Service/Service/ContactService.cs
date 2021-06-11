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
   public class ContactService:GenericService<Contact>, IContactService
    {
        private readonly IContactRepository  _contactRepository;
        private readonly IRepository<Contact> _repository;
       
        public ContactService(IContactRepository contactRepository, IRepository<Contact>  repository) : base(repository)
        {
            this._contactRepository = contactRepository;
            this._repository = repository;
            
        }

       
    }
}
