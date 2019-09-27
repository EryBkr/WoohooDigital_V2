using MyFramework.Core.DataAccess.Abstract;
using MyFramework.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFramework.Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IGenericDal<TEntity> 
        where TEntity:class,IEntity,new()
        where TContext:DbContext,new()
    {
        TContext _dB;
        private DbSet<TEntity> _objectSet;

        public EfEntityRepositoryBase()
        {
            _dB = SingletonRepository<TContext>.CreateDatabase();
            _objectSet = _dB.Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            _objectSet.Add(entity);
            _dB.SaveChanges();
            return entity;
        }

        public void Delete(TEntity entity)
        {
            _objectSet.Remove(entity);
            _dB.SaveChanges();
        }

        public TEntity Get(int id)
        {
             return _objectSet.Find(id);
            
        }

        public IQueryable<TEntity> GetAll()
        {
            return _objectSet;
        }

        public TEntity Update(TEntity entity)
        {
            _objectSet.AddOrUpdate(entity);
            _dB.SaveChanges();
            return entity;

        }
    }
}
