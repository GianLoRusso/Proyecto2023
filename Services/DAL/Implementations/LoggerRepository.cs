using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.DAL.Implementations
{
    internal sealed class LoggerRepository
    {
        #region singleton
        private readonly static LoggerRepository Instance = new LoggerRepository();

        public static LoggerRepository Current
        {
            get
            {
                return Instance;
            }
        }

        private LoggerRepository()
        {

        }
        #endregion

        private string pathLog = ConfigurationManager.AppSettings["PathLog"];
        private string PathFile = ConfigurationManager.AppSettings["LogFileName"];

        public void WriteLog(string message, EventLevel level, string user)
        {
            string FileName = pathLog + DateTime.Now.ToString("yyyyMMdd") + PathFile;

            using (StreamWriter streamWriter = new StreamWriter(FileName, true))
            {
                string fromattedMessage = $"{DateTime.Now.ToString("yyyyMMdd hh:mm:ss tt")} [LEVEL {level.ToString()}] User: {user}, Mensaje: {message}";
                streamWriter.WriteLine(fromattedMessage);
            }
        }
    }
}
