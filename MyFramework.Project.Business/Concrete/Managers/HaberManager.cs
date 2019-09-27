using MyFramework.Core.Aspects.PostSharp;
using MyFramework.Core.CrossCuttingConcerns.Caching.MicrosoftCache;
using MyFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using MyFramework.Project.Business.Abstract;
using MyFramework.Project.Business.ValidationsRules.FluentValidations;
using MyFramework.Project.DataAccess.Abstract;
using MyFramework.Project.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFramework.Project.Business.Concrete.Managers
{
    public class HaberManager : IHaberManager
    {
        IHaberDal _haberDal;
        public HaberManager(IHaberDal haberDal)
        {
            _haberDal = haberDal;
        }

        [FluentValidateAspect(typeof(HaberValidator))]
        [LogAspect(typeof(DatabaseLogger))]
        [LogExceptionAspect(typeof(DatabaseLogger))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Haber Add(Haber entity)
        {
            entity.IslemZamani = DateTime.Now;
            _haberDal.Add(entity);
            return entity;
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogExceptionAspect(typeof(DatabaseLogger))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Delete(Haber entity)
        {
            _haberDal.Delete(entity);
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogExceptionAspect(typeof(DatabaseLogger))]
        public Haber Get(int id)
        {
            return _haberDal.Get(id);
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogExceptionAspect(typeof(DatabaseLogger))]
        [CacheAspect(typeof(MemoryCacheManager), 60)]
        public IQueryable<Haber> GetAll()
        {
            return _haberDal.GetAll();
        }

        [FluentValidateAspect(typeof(HaberValidator))]
        [LogAspect(typeof(DatabaseLogger))]
        [LogExceptionAspect(typeof(DatabaseLogger))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Haber Update(Haber entity)
        {
            entity.IslemZamani = DateTime.Now;
            _haberDal.Update(entity);
            return entity;
        }
    }
}
