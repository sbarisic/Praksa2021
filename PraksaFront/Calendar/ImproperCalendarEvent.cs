namespace PraksaFront
{
    //Do not use this object, it is used just as a go between between javascript and asp.net
    public class ImproperCalendarEvent
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public string Location { get; set; }
        public string Obligation { get; set; }
        public string Time { get; set; }
        public bool AllDay { get; set; }
    }
}