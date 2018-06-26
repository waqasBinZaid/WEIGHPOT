using ITWhiz.ScaleSoft.Common.Infrastructure.Interfaces.Common;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWhiz.ScaleSoft.Common.Common
{
    public class NLogger : Infrastructure.Interfaces.Common.ILogger
    {
        private Logger _logger = LogManager.GetCurrentClassLogger();

        public void Debug(string message)
        {
            _logger.Debug(message);
        }

        public void Exception(string message, Exception exception)
        {
            _logger.Error(exception, message);
        }

        public void Info(string message)
        {
            _logger.Info(message);
        }
    }
}