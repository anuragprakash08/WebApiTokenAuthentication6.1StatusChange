using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTokenAuthentication.Models
{
    public class EventLogger
    {
        public static log4net.ILog Logger = null;

        public enum Event
        {
            START, PROGRESS, END, CLICK
        }

        public static void Log(String ClassName, String MethodName, Event evt, String message)
        {
            string logMessage = "";
            if (Logger == null)
            {
                Logger = log4net.LogManager.GetLogger("EventLogFile");
                log4net.Config.XmlConfigurator.Configure();
            }

            logMessage += ClassName + " - ";
            logMessage += MethodName + " - ";
            logMessage += evt.ToString() + " - ";
            logMessage += message;
            Logger.Info(logMessage);
        }
    }
}