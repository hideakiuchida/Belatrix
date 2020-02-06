using ConsoleApp2.Enums;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace ConsoleApp2.Repositories
{
    public abstract class BaseLoggerRepository
    {
        protected readonly IConfigurationRoot configuration;
        public BaseLoggerRepository()
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appconfig.json", optional: true, reloadOnChange: true);

            configuration = builder.Build();
        }

        protected bool isValidLogMessage(string message)
        {
            if (message == null)
                return false;
            return !(message.Trim().Length == 0);
        }
    }
}
