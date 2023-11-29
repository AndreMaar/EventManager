namespace EventManager
{
    public class Event
    {
        public string Title { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }

        public Event(string Title, string Location, string Category) 
        {
            this.Title = Title;
            this.Location = Location;
            this.Category = Category;
        }
    }
}