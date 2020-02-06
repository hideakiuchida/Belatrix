using ConsoleApp2.Implementations;
using ConsoleApp2.Interfaces;
using ConsoleApp2.Repositories;
using NUnit.Framework;

namespace NUnitTestProject1
{
    //BDD and AAA
    [TestFixture]
    public class JobLoggerUnitTest
    {
        [Test]
        public void Given_ValidMessage_When_CallingMessage_Then_ReturnSuccess()
        {
            IJobLogger logger = new JobLogger(new DatabaseRepository(), new FileRepository(), new ConsoleRepository());

            var success = logger.Message(" This is my message");

            Assert.IsTrue(success);
        }

        [Test]
        public void Given_ValidMessage_When_CallingWarning_Then_ReturnSuccess()
        {
            IJobLogger logger = new JobLogger(new DatabaseRepository(), new FileRepository(), new ConsoleRepository());

            var success = logger.Warning(" This is my warning");

            Assert.IsTrue(success);
        }

        [Test]
        public void Given_ValidMessage_When_CallingError_Then_ReturnSuccess()
        {
            IJobLogger logger = new JobLogger(new DatabaseRepository(), new FileRepository(), new ConsoleRepository());

            var success = logger.Error(" This is my error");

            Assert.IsTrue(success);
        }

        [Test]
        public void Given_NullMessage_When_CallingMessage_Then_ReturnNotSuccess()
        {
            IJobLogger logger = new JobLogger(new DatabaseRepository(), new FileRepository(), new ConsoleRepository());

            var success = logger.Message(default);

            Assert.IsFalse(success);
        }

        [Test]
        public void Given_NullMessage_When_CallingWarning_Then_ReturnNotSuccess()
        {
            IJobLogger logger = new JobLogger(new DatabaseRepository(), new FileRepository(), new ConsoleRepository());

            var success = logger.Warning(default);

            Assert.IsFalse(success);
        }

        [Test]
        public void Given_NullMessage_When_CallingError_Then_ReturnNotSuccess()
        {
            IJobLogger logger = new JobLogger(new DatabaseRepository(), new FileRepository(), new ConsoleRepository());

            var success = logger.Error(default);

            Assert.IsFalse(success);
        }
    }

}
