using ConsoleApp2.Implementations;
using ConsoleApp2.Interfaces;
using ConsoleApp2.Repositories;
using NUnit.Framework;

namespace NUnitTestProject1
{
    [TestFixture]
    public class JobLoggerIntegrationTest
    {
        private readonly ILogRepository _databaseRepository;
        private readonly ILogRepository _fileRepository;
        private readonly ILogRepository _consoleRepository;
        private readonly string ValidMessage = " This is my message";
        private readonly string InvalidMessage = default;
        public JobLoggerIntegrationTest()
        {
            _databaseRepository = new DatabaseRepository();
            _fileRepository = new FileRepository();
            _consoleRepository = new ConsoleRepository();
        }

        [Test]
        public void Given_ValidMessage_When_CallingMessage_Then_ReturnSuccess()
        {
            IJobLogger logger = new JobLogger(_databaseRepository, _fileRepository, _consoleRepository);

            var success = logger.Message(ValidMessage);

            Assert.IsTrue(success);
        }

        [Test]
        public void Given_ValidMessage_When_CallingWarning_Then_ReturnSuccess()
        {
            IJobLogger logger = new JobLogger(_databaseRepository, _fileRepository, _consoleRepository);

            var success = logger.Warning(ValidMessage);

            Assert.IsTrue(success);
        }

        [Test]
        public void Given_ValidMessage_When_CallingError_Then_ReturnSuccess()
        {
            IJobLogger logger = new JobLogger(_databaseRepository, _fileRepository, _consoleRepository);

            var success = logger.Error(ValidMessage);

            Assert.IsTrue(success);
        }

        [Test]
        public void Given_NullMessage_When_CallingMessage_Then_ReturnNotSuccess()
        {
            IJobLogger logger = new JobLogger(_databaseRepository, _fileRepository, _consoleRepository);

            var success = logger.Message(InvalidMessage);

            Assert.IsFalse(success);
        }

        [Test]
        public void Given_NullMessage_When_CallingWarning_Then_ReturnNotSuccess()
        {
            IJobLogger logger = new JobLogger(_databaseRepository, _fileRepository, _consoleRepository);

            var success = logger.Warning(InvalidMessage);

            Assert.IsFalse(success);
        }

        [Test]
        public void Given_NullMessage_When_CallingError_Then_ReturnNotSuccess()
        {
            IJobLogger logger = new JobLogger(_databaseRepository, _fileRepository, _consoleRepository);

            var success = logger.Error(InvalidMessage);

            Assert.IsFalse(success);
        }
    }
}
