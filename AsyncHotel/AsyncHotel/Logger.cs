using AsyncHotel.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AsyncHotel
{
    sealed class Logger:ILogger
    {
        private static Logger singleInstance = null;


        LoggingRepository logMessage = new LoggingRepository();
        public static Logger GetInstance
        {
            get
            {
                if (singleInstance == null)
                {
                           singleInstance = new Logger();
                  
                }
                return singleInstance;
            }
        }
        private Logger()
        {

        }
        public void LogMessage(string message)
        {
            logMessage.AddLog(message);
       }
    }
}