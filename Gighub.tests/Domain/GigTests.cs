using System.Linq;
using FluentAssertions;
using Gighub.Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gighub.tests.Domain
{
    [TestClass]
    public class GigTests
    {
        // A different approach to write these tests is using BDD. 
        // 
        // GivenAnArtistHasAGig
        //      WhenHeCancelsTheGig
        //          IsCanceledShouldBeSetToTrue
        //          EachAttendeeShouldHaveANotification
        //
        // 
        [TestMethod]
        public void Cancel_WhenCalled_ShouldSetIsCanceledToTrue()
        {
            var gig = new Gig();

            gig.Cancel();

            gig.IsCanceled.Should().BeTrue();
        }

        [TestMethod]
        public void Cancel_WhenCalled_EachAttendeeShouldHaveANotification()
        {
            var gig = new Gig();
            gig.Attendances.Add(new Attendance { Attendee = new ApplicationUser() });

            gig.Cancel();

            //TODO: This could be pushed into the Gig class (eg gig.GetAttendees())
            var attendees = gig.Attendances.Select(a => a.Attendee).ToList();
            attendees[0].UserNotifications.Count.Should().Be(1);
        }
    }
}