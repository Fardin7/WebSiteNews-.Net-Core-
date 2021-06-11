using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Repository.Inerface;
using Service.Interface;
using DAL;

namespace Service.Service
{
   public class GenericService<TEntity> : Iservice<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;
        public GenericService(IRepository<TEntity> repository)
        {
            _repository = repository;
        }
     public void Delete(object id)
        {
            _repository.Delete(id);
        }

        public void Delete(TEntity entityToDelete)
        {
            _repository.Delete(entityToDelete);
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
          return  _repository.Get(filter, orderBy, includeProperties);
        }

        public TEntity GetByID(object id)
        {
           return _repository.GetByID(id);
        }

        public void Insert(TEntity entity)
        {
            
            _repository.Insert(entity);
        }

        public void Update(TEntity entityToUpdate)
        {
            _repository.Update(entityToUpdate);
        }
    }
}
