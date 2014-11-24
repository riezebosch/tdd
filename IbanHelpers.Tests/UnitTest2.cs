using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IbanHelpers;
using System.Diagnostics.CodeAnalysis;

namespace IbanHelpers.Tests
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class UnitTest2
    {
        [TestCategory("Integration Test")]
        [TestCategory("Slow Test")]
        [Owner("Manuel")]
        [TestMethod]
        public void TestMethod1()
        {
            var bank = new Bank(new DummyIbanCkecker(true));
            bank.Stort("NL99RABO0162136188", 32m);

            Assert.AreEqual(32, bank.Krediet);
        }

        class DummyIbanCkecker : IIbanChecker
        {
            private bool _result;
            public DummyIbanCkecker(bool result)
            {
                _result = result;
            }

            public bool Check(string iban)
            {
                return _result;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        [TestCategory("Integration Test")]
        [ExpectedException(typeof(ArgumentException))]
        public void TestOfStortWelHetRekengingNummerControleert()
        {
            // Arrange
            var bank = new Bank(new DummyIbanCkecker(false));
            
            // Act
            bank.Stort("NL99RABO016213", 32m);

            // Assert
            // Methode heeft een expected exception
        }
    }
}
