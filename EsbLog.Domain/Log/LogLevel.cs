using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsbLog.Domain.Log
{
    public enum LogLevel
    {
        Trace,
        Debug,
        Info,
        Warn,
        Error,
        Fatal
    }

    public static class LogLevelExtention
    {
        public static string AsName(this LogLevel level)
        {
            var displayAttr = level.GetType().GetCustomAttributes(typeof(DisplayAttribute), false)
                                    .FirstOrDefault() as DisplayAttribute;
            return displayAttr == null?level.ToString().ToLower()
                                    :displayAttr.Name;
        }

        public static IEnumerable<string> GetLogLevelNames()
        {
            var type = typeof(LogLevel);
            return type.GetEnumNames();
        }
    }
}
