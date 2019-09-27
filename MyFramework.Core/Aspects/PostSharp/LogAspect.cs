using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MyFramework.Core.CrossCuttingConcerns.Logging;
using MyFramework.Core.CrossCuttingConcerns.Logging.Log4Net;
using PostSharp.Aspects;
namespace MyFramework.Core.Aspects.PostSharp
{
    [Serializable]
    public class LogAspect : OnMethodBoundaryAspect
    {
        private Type _loggerType;
        private LoggerService _loggerService;
        private LogDetail logDetail;
        public LogAspect(Type loggerType)
        {
            _loggerType = loggerType;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            if (_loggerType.BaseType != typeof(LoggerService))
            {
                throw new Exception("Wrong Logger Type");
            }
            _loggerService = (LoggerService)Activator.CreateInstance(_loggerType);
            base.RuntimeInitialize(method);
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            if (!_loggerService.IsInfoEnabled)
            {
                return;
            }

            try
            {
                var logParameters = args.Method.GetParameters()
                    .Select((t, i) =>
                    new LogParameter { Name = t.Name, Type = t.ParameterType.Name, Value = args.Arguments.GetArgument(i) }).ToList();

                 logDetail = new LogDetail()
                {
                    FullName = args.Method.DeclaringType == null ? null : args.Method.DeclaringType.Name,
                    MethodName = args.Method.Name,
                    LogParameters = logParameters
                };

                _loggerService.Info(logDetail);
            }
            catch (Exception e)
            {

              
            }

            base.OnEntry(args);
        }


    }
}
