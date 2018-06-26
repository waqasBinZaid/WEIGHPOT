using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWhiz.ScaleSoft.Common.Infrastructure.Interfaces.Common
{
    public interface ILogger
    {
        void Info(string message);
        void Debug(string message);
        void Exception(string message, Exception exception);
    }
}
