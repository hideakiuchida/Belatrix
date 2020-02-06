using ConsoleApp2.Enums;
using ConsoleApp2.Interfaces;

namespace ConsoleApp2.Implementations
{
    public class JobLogger : IJobLogger
    {
        private readonly ILogRepository _databaseLogRepository;
        private readonly ILogRepository _fileLogRepository;
        private readonly ILogRepository _consoleLogRepository;
        public JobLogger(ILogRepository databaseLogRepository, ILogRepository fileLogRepository, ILogRepository consoleLogRepository)
        {
            _databaseLogRepository = databaseLogRepository;
            _fileLogRepository = fileLogRepository;
            _consoleLogRepository = consoleLogRepository;
        }
        public bool Error(string message)
        {
            return Log(message, TypeLogEnum.Error);
        }

        public bool Message(string message)
        {
            return Log(message, TypeLogEnum.Message);
        }

        public bool Warning(string message)
        {
            return Log(message, TypeLogEnum.Warning);
        }

        private bool Log(string message, TypeLogEnum typeLogEnum)
        {
            var succededDB = _databaseLogRepository.Log(message, typeLogEnum);
            var succededFile = _fileLogRepository.Log(message, typeLogEnum);
            var succededConsole = _consoleLogRepository.Log(message, typeLogEnum);
            return succededConsole && succededDB && succededFile;

        }
    }
}
