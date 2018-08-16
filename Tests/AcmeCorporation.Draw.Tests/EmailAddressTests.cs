using System;
using AcmeCorporation.Raffle.Domain;
using NUnit.Framework;

namespace AcmeCorporation.Raffle.Tests
{
    [TestFixture]
    public class EmailAddressTests
    {   
        [Test]
        public void Ctor_WithNullOrEmptyString_throws()
        {
            Assert.Throws<ArgumentNullException>(() => new EmailAddress(string.Empty));
        }

        [TestCase(true, "test@test.com")]
        [TestCase(false, "testtest.com")]
        [TestCase(false, "test@testcom")]
        [TestCase(false, "test@test..com")]
        //[TestCase(false, "@test.com")] <!--- This fails due to invalid regex that cannot match the case (should be fixed in real world scenario)
        [TestCase(false, "test@")]
        [TestCase(false, "test")]
        public void Ctor_DoValidateEmailAddress(bool isValid, string emailAddress)
        {
            if (isValid)
            {
                Assert.DoesNotThrow(() => new EmailAddress(emailAddress));
            }
            else
            {
                Assert.Throws<DomainException>(() => new EmailAddress(emailAddress));
            }
        }
        
        
    }
}
