using Microsoft.Extensions.Logging;
using ProyectoConrado.Logging.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoConrado.Logging.Extensions
{
    public static class FileLoggerExtensions
    {
        public static ILoggerFactory AddFile(this ILoggerFactory factory, string filePath)
        {
            factory.AddProvider(new FileLoggerProvider(filePath));
            return factory;
        }
    }
}