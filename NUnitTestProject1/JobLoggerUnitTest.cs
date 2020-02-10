using ConsoleApp2.Enums;
using ConsoleApp2.Implementations;
using ConsoleApp2.Interfaces;
using ConsoleApp2.Repositories;
using Moq;
using NUnit.Framework;

namespace NUnitTestProject1
{
    //BDD and AAA
    [TestFixture]
    public class JobLoggerUnitTest
    {
        private readonly ILogRepository _databaseRepository;
        private readonly ILogRepository _fileRepository;
        private readonly ILogRepository _consoleRepository;
        private readonly string ValidMessage = " This is my message";
        private readonly string InvalidMessage = default;
        public JobLoggerUnitTest()
        {
            var databaseRepositoryMock = new Mock<DatabaseRepository>(MockBehavior.Strict);
            databaseRepositoryMock.Setup(x => x.Log(ValidMessage, TypeLogEnum.Message)).Returns(true);
            databaseRepositoryMock.Setup(x => x.Log(ValidMessage, TypeLogEnum.Warning)).Returns(true);
            databaseRepositoryMock.Setup(x => x.Log(ValidMessage, TypeLogEnum.Error)).Returns(true);
            databaseRepositoryMock.Setup(x => x.Log(InvalidMessage, TypeLogEnum.Message)).Returns(false);
            databaseRepositoryMock.Setup(x => x.Log(InvalidMessage, TypeLogEnum.Warning)).Returns(false);
            databaseRepositoryMock.Setup(x => x.Log(InvalidMessage, TypeLogEnum.Error)).Returns(false);
            _databaseRepository = databaseRepositoryMock.Object;

            var fileRepositoryMock = new Mock<FileRepository>(MockBehavior.Strict);
            fileRepositoryMock.Setup(x => x.Log(ValidMessage, TypeLogEnum.Message)).Returns(true);
            fileRepositoryMock.Setup(x => x.Log(ValidMessage, TypeLogEnum.Warning)).Returns(true);
            fileRepositoryMock.Setup(x => x.Log(ValidMessage, TypeLogEnum.Error)).Returns(true);
            fileRepositoryMock.Setup(x => x.Log(InvalidMessage, TypeLogEnum.Message)).Returns(false);
            fileRepositoryMock.Setup(x => x.Log(InvalidMessage, TypeLogEnum.Warning)).Returns(false);
            fileRepositoryMock.Setup(x => x.Log(InvalidMessage, TypeLogEnum.Error)).Returns(false);
            _fileRepository = fileRepositoryMock.Object;

            var consoleRepositoryMock = new Mock<ConsoleRepository>(MockBehavior.Strict);
            consoleRepositoryMock.Setup(x => x.Log(ValidMessage, TypeLogEnum.Message)).Returns(true);
            consoleRepositoryMock.Setup(x => x.Log(ValidMessage, TypeLogEnum.Warning)).Returns(true);
            consoleRepositoryMock.Setup(x => x.Log(ValidMessage, TypeLogEnum.Error)).Returns(true);
            consoleRepositoryMock.Setup(x => x.Log(InvalidMessage, TypeLogEnum.Message)).Returns(false);
            consoleRepositoryMock.Setup(x => x.Log(InvalidMessage, TypeLogEnum.Warning)).Returns(false);
            consoleRepositoryMock.Setup(x => x.Log(InvalidMessage, TypeLogEnum.Error)).Returns(false);
            _consoleRepository = consoleRepositoryMock.Object;
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
            IJobLogger logger = new JobLogger(_databaseRepository, _fileRepository,_consoleRepository);

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
