using System;

//Do not use this object, it is used just as a go between between javascript and asp.net
public class ImproperCalendarEvent
{
    public int id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public string location { get; set; }
    public DateTime date { get; set; }
    public string time { get; set; }
    public bool requirement { get; set; }
}
