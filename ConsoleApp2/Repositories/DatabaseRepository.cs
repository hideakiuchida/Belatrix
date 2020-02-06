using ConsoleApp2.Enums;
using ConsoleApp2.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp2.Repositories
{
    public class DatabaseRepository : BaseLoggerRepository, ILogRepository
    {
        public bool Log(string message, TypeLogEnum typeLogEnum)
        {
            if (!isValidLogMessage(message)) return false;
            var messageTrimmed = message.Trim();

            try
            {
                var connectionString = configuration.GetConnectionString("SqlConnection");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var type = ((int)typeLogEnum).ToString();
                    SqlCommand sqlCommand = new SqlCommand($"Insert into Logger (Message, Type) Values('{messageTrimmed}','{ type }')", connection);
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
