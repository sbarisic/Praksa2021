using System;

/// <summary>
/// Summary description for CalendarEvent
/// </summary>
public class CalendarEvent
{
    public int id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public string location { get; set; }
    public DateTime date { get; set; }
    public string time { get; set; }
    public bool requirement { get; set; }
}
