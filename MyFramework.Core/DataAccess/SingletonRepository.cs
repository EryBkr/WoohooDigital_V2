using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFramework.Core.DataAccess.EntityFramework
{
   public class SingletonRepository<TContext> where TContext:class,new()
    {
        private static TContext _dB;
        private static object _sync = new object();
        protected SingletonRepository()
        {

        }

        public static TContext CreateDatabase()
        {
            if (_dB==null)
            {
                lock (_sync)
                {
                    if (_dB == null)
                    {
                        _dB = new TContext();
                    }

                }

            }
            return _dB;
        }

    }
}
