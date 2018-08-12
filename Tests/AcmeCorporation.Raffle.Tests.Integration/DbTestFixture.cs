using System;
using AcmeCorporation.Raffle.Infrastructure.Storage;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace AcmeCorporation.Raffle.Tests.Integration
{
    [TestFixture]
    public abstract class DbTestFixture
    {

        protected RaffleDbContext Context;
        
        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<RaffleDbContext>();
            contextOptions.UseInMemoryDatabase("RaffleTestDb");
            
            Context = new RaffleDbContext(contextOptions.Options);
            
            DoSetup();
        }

        [TearDown]
        public void TearDown()
        {
            Context.Dispose();
            Context = null;
        }

        public virtual void DoSetup() {}
    }
}
