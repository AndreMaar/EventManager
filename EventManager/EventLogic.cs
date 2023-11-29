using System.Linq;

namespace EventManager
{
    public class EventLogic
    {
        private List<string> categories = new List<string>();
        private List<Event> events = new List<Event>();
        private List<Event> favorites = new List<Event>();
            
        public void AddCategory(string category)
        {
            if (category != null && !categories.Contains(category))
            {
                categories.Add(category);
            }
        }

        public void RemoveCategory(string category)
        {
            if (category != null && categories.Contains(category))
            {
                categories.Remove(category);

                // Update events removing the category
                foreach (var e in events)
                {
                    if (e.Category == category)
                    {
                        e.Category = null;
                    }
                }
            }
        }

        public void AddEvent(Event newEvent)
        {
            if (newEvent != null && categories.Contains(newEvent.Category))
            {
                events.Add(newEvent);
            }
        }

        public void RemoveEvent(Event existingEvent)
        {
            if (existingEvent != null)
            {
                events.Remove(existingEvent);
            }
        }

        public void AddToFavorites(Event favoriteEvent)
        {
            if (favoriteEvent != null)
            {
                favorites.Add(favoriteEvent);
            }
        }

        public void RemoveFromFavorites(Event unfavoriteEvent)
        {
            if (unfavoriteEvent != null)
            {
                favorites.Remove(unfavoriteEvent);
            }
        }

        public List<string> GetCategories()
        {
            return categories;
        }      


        public List<Event> GetFavoriteEvents()
        {
            // Implement logic to sort favorites by title in descending order
            return favorites.OrderByDescending(e => e.Title).ToList();
        }

        public List<Event> GetEventsByCategory(string category)
        {
            // Implement logic to filter and sort events by category and title
            return events.Where(e => e.Category == category)
                         .OrderByDescending(e => e.Title)
                         .ToList();
        }
    }
}