using FluentAssertions;
using Gighub.Core.Models;
using Gighub.Persistence;
using Gighub.Persistence.Repositories;
using Gighub.Tests.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Gighub.Tests.Persistence.Repositories
{
    [TestClass]
    public class GigRepositoryTests
    {
        private GigRepository _repository;
        private Mock<DbSet<Gig>> _mockGigs;

        [TestInitialize]
        public void TestInitialize()
        {
            var mockContext = new Mock<IApplicationDbContext>();
            _mockGigs = new Mock<DbSet<Gig>>();
            mockContext.Setup(c => c.Gigs).Returns(_mockGigs.Object);

            _repository = new GigRepository(mockContext.Object);

        }

        [TestMethod] 
        public void GetFutureGigs_GigIsInThePast_ShouldNotBeReturned()
        {
            var gig = new Gig() { DateTime = DateTime.Now.AddDays(-1), ArtistId = "1" };
            _mockGigs.SetSource(new [] { gig });

            var gigs = _repository.GetFutureGigs("1");

            gigs.Should().BeEmpty();
        }

    }
}
