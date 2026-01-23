using EventScheduler.Core.Entities;
using EventScheduler.Db.Tests.Repositories.SutBuilders;
using EventScheduler.TestInfrastructure.Core;
using EventScheduler.TestInfrastructure.EqualityComparers;

namespace EventScheduler.Db.Tests.Repositories
{
    [TestFixture]
    public class EventRepositoryTests
    {
        [TestFixture]
        public class SaveEvent
        {
            [Test]
            public void ShouldReturnNewEventId()
            {
                // Arrange
                using var sutBuilder = CreateSutBuilder();
                var sut = sutBuilder.Build();
                var saveCommand = SaveEventCommandFactory.Create().Build();

                // Act
                var actual = sut.SaveEvent(saveCommand);
                var saved = sut.GetEventById(actual);

                // Assert
                Assert.That(saved, Is.EqualTo(EventFactory.Create().From(saveCommand).WithId(actual).Build()).Using(EventEqualityComparer.Instance));
            }
        }

        [TestFixture]
        public class GetEvents
        {
            [Test]
            public void ShouldReturnAllEvents()
            {
                // Arrange
                using var sutBuilder = CreateSutBuilder();
                var sut = sutBuilder.Build();
                var saveCommands = SaveEventCommandFactory.Create().Build(10);
                List<Event> expected = [];
                foreach (var command in saveCommands)
                {
                    var id = sut.SaveEvent(command);
                    expected.Add(EventFactory.Create().From(command).WithId(id).Build());
                }

                // Act
                var actual = sut.GetEvents().ToList();

                // Assert
                Assert.That(actual, Is.EquivalentTo(expected).Using(EventEqualityComparer.Instance));
            }
        }

        [TestFixture]
        public class GetEventById
        {
            [Test]
            public void GivenEventExistsForId_ShouldReturnEvent()
            {
                // Arrange
                using var sutBuilder = CreateSutBuilder();
                var sut = sutBuilder.Build();
                var saveCommand = SaveEventCommandFactory.Create().Build();
                var id = sut.SaveEvent(saveCommand);
                var expected = EventFactory.Create().From(saveCommand).WithId(id).Build();

                // Act
                var actual = sut.GetEventById(id);

                // Assert
                Assert.That(actual, Is.EqualTo(expected).Using(EventEqualityComparer.Instance));
            }

            [Test]
            public void GivenEventDoesNotExistForId_ShouldReturnNull()
            {
                // Arrange
                using var sutBuilder = CreateSutBuilder();
                var sut = sutBuilder.Build();

                // Act
                var actual = sut.GetEventById(int.MaxValue);

                // Assert
                Assert.That(actual, Is.Null);
            }
        }

        [TestFixture]
        public class UpdateUser
        {
            [Test]
            public void ShouldUpdateUserDetails()
            {
                // Arrange
                using var sutBuilder = CreateSutBuilder();
                var sut = sutBuilder.Build();
                var saveCommand = SaveEventCommandFactory.Create().Build();
                var id = sut.SaveEvent(saveCommand);
                var updateCommand = UpdateEventCommandFactory.Create().Build();
                var expected = EventFactory.Create().From(updateCommand).WithId(id).Build();

                // Act
                sut.UpdateEvent(id, updateCommand);
                var updatedEvent = sut.GetEventById(id);

                // Assert
                Assert.That(updatedEvent, Is.EqualTo(expected).Using(EventEqualityComparer.Instance));
            }
        }

        [TestFixture]
        public class DeleteUser
        {
            [Test]
            public void ShouldDeleteUser()
            {
                // Arrange
                using var sutBuilder = CreateSutBuilder();
                var sut = sutBuilder.Build();
                var saveCommand = SaveEventCommandFactory.Create().Build();
                var id = sut.SaveEvent(saveCommand);

                // Act
                sut.DeleteEvent(id);

                // Assert
                Assert.That(() => sut.GetEventById(id), Is.Null);
            }
        }
        public static EventRepositorySutBuilder CreateSutBuilder()
        {
            return new EventRepositorySutBuilder();
        }
    }
}
