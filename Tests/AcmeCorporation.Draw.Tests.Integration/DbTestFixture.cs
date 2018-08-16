using System;
using AcmeCorporation.Raffle.Infrastructure.Storage;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace AcmeCorporation.Raffle.Tests.Integration
{
    [TestFixture]
    public abstract class DbTestFixture
    {

        protected DrawDbContext Context;
        
        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<DrawDbContext>();
            contextOptions.UseInMemoryDatabase("RaffleTestDb");
            
            Context = new DrawDbContext(contextOptions.Options);
            
            DoSetup();
        }

        [TearDown]
        public void TearDown()
        {
            DoTeardown();
            Context.Dispose();
            Context = null;
        }

        public virtual void DoSetup() {}
        public virtual void DoTeardown() {}
    }
}
