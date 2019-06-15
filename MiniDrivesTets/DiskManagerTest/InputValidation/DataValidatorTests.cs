using DiskManager.InputValidation;
using NUnit.Framework;

namespace DiskManagerTest.InputValidation
{
    [TestFixture]
    public class DataValidatorTests
    {
        IDataValidator dataValidator;

        [SetUp]
        public void Setup()
        {
            dataValidator = new DataValidator();
        }

        [Test]
        public void shouldGiveErrorOnNullParameter()
        {
            Assert.IsFalse(dataValidator.validateInputData("1,2", null));
        }

        [Test]
        public void shouldGiveErrorOnEmptyParameter()
        {
            Assert.IsFalse(dataValidator.validateInputData("", "1,2"));
        }

        [Test]
        public void shouldGiveErrorOnInvalidDiskUsage()
        {
            Assert.IsFalse(dataValidator.validateInputData("5,A,3", "1,2,3"));
        }

        [Test]
        public void shouldGiveErrorOnOutOfRangeDiskUsage()
        {
            Assert.IsFalse(dataValidator.validateInputData("5,1500,3", "1,2,3"));
        }

        [Test]
        public void shouldGiveErrorOnInvalidDiskSpace()
        {
            Assert.IsFalse(dataValidator.validateInputData("5,10,3", "1,,3"));
        }

        [Test]
        public void shouldGiveErrorOnOutOfRangeDiskSpace()
        {
            Assert.IsFalse(dataValidator.validateInputData("5,500,3", "1,-2,3"));
        }

        [Test]
        public void shouldGiveErrorOnNonMatchingArrays()
        {
            Assert.IsFalse(dataValidator.validateInputData("100,200,300,400,500", "1000,1000,1000"));
        }

        [Test]
        public void shouldGenerateRightArrays()
        {
            //Right response when processing
            Assert.IsTrue(dataValidator.validateInputData("100,200,300,400,500", "1000,1000,1000,1000,1000"));

            //Right used array
            Assert.AreEqual(dataValidator.used, new int[] { 100, 200, 300, 400, 500 });

            //Right total array
            Assert.AreEqual(dataValidator.total, new int[] { 1000, 1000, 1000, 1000, 1000 });
        }
    }
}
