using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IbanHelpers;

namespace IbanHelpers.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Given_AValidIban_WhenExecutingCheck_ThenShouldReturnTrue()
        {
            // Arrange
            string iban = "NL78 RABO 0162 1361 88";
            var checker = new IbanChecker();

            // Act
            bool result = checker.Check(iban);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestIbanCheckMetTeKorteIban()
        {
            string iban = "NL05 RABO 1234 1234 0";
            var checker = new IbanChecker();

            bool result = checker.Check(iban);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestIbanMetVerkeerdeLandCode()
        {
            string iban = "NE05 RABO 1234 1234 00";
            var checker = new IbanChecker();

            bool result = checker.Check(iban);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestIbanMetVerkeerdControleGetal()
        {
            string iban = "NL04 RABO 1234 1234 00";
            var checker = new IbanChecker();

            bool result = checker.Check(iban);

            Assert.IsFalse(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestCheckMetNull()
        {
            var check = new IbanChecker();
            check.Check(null);
        }

        [TestMethod]
        public void TestControleGetal()
        {
            string iban = "NL78RABO0162136188";

            var result = IbanChecker.BerekenControleGetal(iban);
            Assert.AreEqual("78", result);
        }
    }

}
