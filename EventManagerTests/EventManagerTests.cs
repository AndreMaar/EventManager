using EventManager;


namespace EventManagerTests
{
    public class EventManagerTests
    {
        

        [Fact]
        public void AddCategory_ShouldAddCategory()
        {
            // Arrange
            var eventManager = new EventLogic();

            // Act
            eventManager.AddCategory("MusicLesson");

            // Assert
            Assert.Contains("MusicLesson", eventManager.GetCategories());
        }

        [Fact]
        public void RemoveCategory_ShouldRemoveCategory()
        {
            // Arrange
            var eventManager = new EventLogic();
            eventManager.AddCategory("MusicLesson");

            // Act
            eventManager.RemoveCategory("MusicLesson");

            // Assert
            Assert.DoesNotContain("MusicLesson", eventManager.GetCategories());
        }
        [Fact]
        public void AddEvent_ShouldAddEvent()
        {
            // Arrange
            var eventManager = new EventLogic();
            var newEvent = new Event("Concert", "Venue", "Music");

            // Act
            eventManager.AddEvent(newEvent);

            // Assert
            Assert.Contains(newEvent,eventManager.GetEventsByCategory("Music"));
        }

        [Fact]
        public void RemoveEvent_ShouldRemoveEvent()
        {
            // Arrange
            var eventManager = new EventLogic();
            var existingEvent = new Event("Concert", "Venue", "Music");
            eventManager.AddEvent(existingEvent);

            // Act
            eventManager.RemoveEvent(existingEvent);

            // Assert
            Assert.DoesNotContain(existingEvent, eventManager.GetEventsByCategory("Music"));
        }

        [Fact]
        public void AddToFavorites_ShouldAddToFavorites()
        {
            // Arrange
            var eventManager = new EventLogic();
            var favoriteEvent = new Event("Picnic", "Beach", "Outdoor");

            // Act
            eventManager.AddToFavorites(favoriteEvent);

            // Assert
            Assert.Contains(favoriteEvent,eventManager.GetFavoriteEvents());
        }

        [Fact]
        public void RemoveFromFavorites_ShouldRemoveFromFavorites()
        {
            // Arrange
            var eventManager = new EventLogic();
            Event unfavoriteEvent = new Event("Picnic", "Beach", "Outdoor");
            //eventManager.AddToFavorites(unfavoriteEvent);

            // Act
            eventManager.RemoveFromFavorites(unfavoriteEvent);

            // Assert
            Assert.DoesNotContain(unfavoriteEvent, eventManager.GetFavoriteEvents());
        }
        [Fact]
        public void GetFavoriteEvents_ShouldReturnSortedFavorites()
        {
            // Arrange
            var eventManager = new EventLogic();
            Event event1 = new Event("Concert A", "Venue A", "Music");
            Event event2 = new Event("Concert B", "Venue B", "Music");
            Event event3 = new Event("Festival", "Park", "Outdoor");

            eventManager.AddToFavorites(event1);
            eventManager.AddToFavorites(event2);
            eventManager.AddToFavorites(event3);

            // Act
            var favoriteEvents = eventManager.GetFavoriteEvents();

            // Assert
            Assert.Equal(favoriteEvents, new[] { event3, event2, event1});
        }
        [Fact]
        public void GetEventsByCategory_ShouldReturnSortedEvents()
        {
            // Arrange
            var eventManager = new EventLogic();
            Event event1 = new Event("Concert B","Venue B","Music");            
            Event event2 = new Event("Concert A", "Venue A", "Music");
            Event event3 = new Event("Festival", "Park", "Outdoor");

            eventManager.AddEvent(event1);
            eventManager.AddEvent(event2);
            eventManager.AddEvent(event3);

            // Act
            var events = eventManager.GetEventsByCategory("Music");

            // Assert
            Assert.Equal(events, new[] { event1, event2 });
        }
    }
}