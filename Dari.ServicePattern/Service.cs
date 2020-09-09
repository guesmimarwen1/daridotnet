using Dari.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dari.ServicePattern
{

    public abstract class Service<TEntity> : IService<TEntity> where TEntity : class
    {

        IUnitOfWork utwk;
        private IUnitOfWork utwk1;
        private IUnitOfWork ut;

        protected Service(Dari.Data.Infrastructure.IUnitOfWork utwk)
        {
            this.utwk = utwk;
        }

        public Service()
        {
        }



        public virtual void Add(TEntity entity)
        {
            ////_repository.Add(entity);
            utwk.GetRepository<TEntity>().Add(entity);

        }

        public virtual void Update(TEntity entity)
        {
            //_repository.Update(entity);
            utwk.GetRepository<TEntity>().Update(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            //   _repository.Delete(entity);
            utwk.GetRepository<TEntity>().Delete(entity);
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> where)
        {
            // _repository.Delete(where);
            utwk.GetRepository<TEntity>().Delete(where);
        }

        public virtual TEntity GetById(int id)
        {
            //  return _repository.GetById(id);
            return utwk.GetRepository<TEntity>().GetById(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return utwk.GetRepository<TEntity>().GetAll();
            //return _repository.GetById(id);
            //  return utwk.getRepository<TEntity>().GetById(id);
        }

        public virtual IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, bool>> orderBy = null)
        {
            //  return _repository.GetAll();
            return utwk.GetRepository<TEntity>().GetMany(filter, orderBy);
        }

       // public virtual TEntity Get(Expression<Func<TEntity, bool>> where)
        //{
            //return _repository.Get(where);
           // return utwk.GetRepository<TEntity>().Get(where);
       // }



        public void Commit()
        {

            utwk.Commit();


        }


        public void Dispose()
        {
            utwk.Dispose();
        }

        public void dispose()
        {
            throw new NotImplementedException();
        }
    }
}
