using System;

namespace EventManagerConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the EventManager
            EventManager.EventLogic eventManager = new EventManager.EventLogic();

            // Example: Add categories
            eventManager.AddCategory("Music");
            eventManager.AddCategory("Sports");

            // Example: Add events
            EventManager.Event event1 = new EventManager.Event { Title = "Concert", Location = "Venue A", Category = "Music" };
            EventManager.Event event2 = new EventManager.Event { Title = "Football Match", Location = "Stadium X", Category = "Sports" };

            eventManager.AddEvent(event1);
            eventManager.AddEvent(event2);

            // Example: Add to favorites
            eventManager.AddToFavorites(event1);

            // Example: Remove from favorites
            eventManager.RemoveFromFavorites(event2);

            // Example: Get favorite events
            Console.WriteLine("Favorite Events:");
            foreach (var favEvent in eventManager.GetFavoriteEvents())
            {
                Console.WriteLine($"{favEvent.Title} - {favEvent.Location} ({favEvent.Category})");
            }

            // Example: Get events by category
            Console.WriteLine("\nEvents in 'Music' category:");
            foreach (var categoryEvent in eventManager.GetEventsByCategory("Music"))
            {
                Console.WriteLine($"{categoryEvent.Title} - {categoryEvent.Location}");
            }

            // Example: Remove category
            eventManager.RemoveCategory("Sports");

            // Example: Remove event
            eventManager.RemoveEvent(event1);

            Console.WriteLine("\nRemaining Categories:");
            foreach (var category in eventManager.Categories)
            {
                Console.WriteLine(category);
            }

            Console.WriteLine("\nRemaining Events:");
            foreach (var remainingEvent in eventManager.Events)
            {
                Console.WriteLine($"{remainingEvent.Title} - {remainingEvent.Location}");
            }
        }
    }
}


