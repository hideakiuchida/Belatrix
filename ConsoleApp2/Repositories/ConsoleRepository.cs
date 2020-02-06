using ConsoleApp2.Enums;
using ConsoleApp2.Interfaces;
using System;

namespace ConsoleApp2.Repositories
{
    public class ConsoleRepository : BaseLoggerRepository, ILogRepository
    {
        public bool Log(string message, TypeLogEnum typeLogEnum)
        {
            if (!isValidLogMessage(message)) return false;
            var messageTrimmed = message.Trim();

            if (typeLogEnum == TypeLogEnum.Error)
                Console.ForegroundColor = ConsoleColor.Red;
            if (typeLogEnum == TypeLogEnum.Warning)
                Console.ForegroundColor = ConsoleColor.Yellow;
            if (typeLogEnum == TypeLogEnum.Message)
                Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine($"{DateTime.Now.ToShortDateString()} {messageTrimmed}");
            return true;
        }
    }
}
