using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFramework.Core.CrossCuttingConcerns.Logging.Log4Net
{
    [Serializable]
   public class SerializableLogEvent
    {
        LoggingEvent _loggingEvent;

        public SerializableLogEvent(LoggingEvent loggingEvent)
        {
            _loggingEvent = loggingEvent;
        }

        public string UserName {get{return _loggingEvent.UserName;}}
        public object MessageObject { get { return _loggingEvent.MessageObject; } }
    }
}
