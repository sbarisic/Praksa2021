using System;

/// <summary>
/// Summary description for CalendarEvent
/// </summary>
public class CalendarEvent
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Date { get; set; }
    public string Time { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public string Obligation { get; set; }
    public int IdAttendant { get; set; }
}
