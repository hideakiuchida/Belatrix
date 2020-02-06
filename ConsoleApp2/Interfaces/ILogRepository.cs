using ConsoleApp2.Enums;

namespace ConsoleApp2.Interfaces
{
    public interface ILogRepository
    {
        bool Log(string message, TypeLogEnum typeLogEnum);
    }
}
