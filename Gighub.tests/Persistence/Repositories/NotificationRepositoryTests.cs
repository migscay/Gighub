using System.Linq;
using FluentAssertions;
using Gighub.Core.Models;
using Gighub.Persistence;
using Gighub.Persistence.Repositories;
using Gighub.Tests.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Data.Entity;

namespace GigHub.Tests.Persistence.Repositories
{
    [TestClass]
    public class NotificationRepositoryTests
    {
        private NotificationRepository _repository;
        private Mock<DbSet<UserNotification>> _mockNotifications;
        //private Mock<DbSet<Notification>> _mockNotificationsN;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockNotifications = new Mock<DbSet<UserNotification>>();

            var mockContext = new Mock<IApplicationDbContext>();
            mockContext.SetupGet(c => c.UserNotifications).Returns(_mockNotifications.Object);
 
            _repository = new NotificationRepository(mockContext.Object);
        }


        [TestMethod]
        public void GetNewNotificationsFor_NotificationIsRead_ShouldNotBeReturned()
        {
            var notification = Notification.GigCancelled(new Gig());
            var user = new ApplicationUser { Id = "1" };
            var userNotification = new UserNotification(user, notification);
            userNotification.UserId = "1";
            userNotification.Read();

            _mockNotifications.SetSource(new[] { userNotification });

            var notifications = _repository.GetNewNotificationsFor(user.Id);

            notifications.Should().BeEmpty();
        }

        [TestMethod]
        public void GetNewNotificationsFor_NotificationIsForADifferentUser_ShouldNotBeReturned()
        {
            var notification = Notification.GigCancelled(new Gig());
            var user = new ApplicationUser { Id = "1" };
            var userNotification = new UserNotification(user, notification);
            userNotification.UserId = "1";

            _mockNotifications.SetSource(new[] { userNotification });

            var notifications = _repository.GetNewNotificationsFor(user.Id + "-");

            notifications.Should().BeEmpty();
        }

        [TestMethod]
        public void GetNewNotificationsFor_NewNotificationForTheGivenUser_ShouldBeReturned()
        {
            var notification = Notification.GigCancelled(new Gig());
            var user = new ApplicationUser { Id = "1" };
            var userNotification = new UserNotification(user, notification);
            userNotification.UserId = "1";

            _mockNotifications.SetSource(new[] { userNotification });

            var notifications = _repository.GetNewNotificationsFor(user.Id);

            notifications.Should().HaveCount(1);
            notifications.First().Should().Be(notification);
        }
    }
}