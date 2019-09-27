using MyFramework.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFramework.Core.DataAccess.Abstract
{
    public interface IGenericDal<T> where T:class,IEntity,new()
    {
        IQueryable<T> GetAll();
        T Add(T entity);
        void Delete(T entity);
        T Update(T entity);
        T Get(int id);
    }
}
