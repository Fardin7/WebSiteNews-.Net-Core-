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
   public class CommentService:GenericService<Comment>, ICommentService
    {
        private readonly ICommentRepository  _commentRepository;
        private readonly IRepository<Comment> _repository;
       
        public CommentService(ICommentRepository commentRepository, IRepository<Comment>  repository) : base(repository)
        {
            this._commentRepository = commentRepository;
            this._repository = repository;
            
        }

       
    }
}
