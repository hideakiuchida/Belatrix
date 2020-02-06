using ConsoleApp2.Enums;
using ConsoleApp2.Interfaces;
using System;
using System.IO;
using System.Text;

namespace ConsoleApp2.Repositories
{
    public class FileRepository : BaseLoggerRepository, ILogRepository
    {
        public bool Log(string message, TypeLogEnum typeLogEnum)
        {
            if (!isValidLogMessage(message)) return false;
            var messageTrimmed = message.Trim();
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                var typeLog = typeLogEnum.ToString();
                string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
                var fileDirectory = configuration.GetSection("AppSettings:LogFileDirectory").Value + "LogFile" + currentDate + ".txt";
                if (File.Exists(fileDirectory))
                {
                    var text = File.ReadAllText(fileDirectory);
                    if (!string.IsNullOrEmpty(text))
                        stringBuilder.Append($"{text} {currentDate} {typeLog}: {messageTrimmed}");
                }
                else
                    stringBuilder.Append($"{currentDate} {typeLog}: {messageTrimmed}");
                File.WriteAllText(fileDirectory, stringBuilder.ToString());
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
