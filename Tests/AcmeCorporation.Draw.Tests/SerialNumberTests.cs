using System;
using AcmeCorporation.Draw.Domain;
using NUnit.Framework;

namespace AcmeCorporation.Draw.Tests
{
    [TestFixture]
    public class SerialNumberTests
    {
        private SerialNumber sut;

        [SetUp]
        public void Setup()
        {
            sut = SerialNumber.CreateNewSerialNumber(Guid.NewGuid().ToString());
        }

        [Test]
        public void Use_UsageCount_ShoulbeOne()
        {
            sut.Use();
            
            Assert.That(sut.UsageCount, Is.EqualTo(1));
        }
        
        [Test]
        public void Use_UsageCount_ShoulbeTwo()
        {
            sut.Use();
            sut.Use();
            
            Assert.That(sut.UsageCount, Is.EqualTo(2));
        }
        
        [Test]
        public void Use_ThirdTime_Throws()
        {
            sut.Use();
            sut.Use();
            
            Assert.Throws<DomainException>(() => sut.Use());
        }
    }
}