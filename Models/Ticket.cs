namespace farouk.Models;
public class Ticket
{
    public int Id { get; set; } 
    public string Title { get; set; }
    public string Priority { get; set; } = "a";
    public string Status { get; set; } = "ASSIGNED" ;
    public DateTime createdAt { get; set; }
    public DateTime closedAt { get; set; }
}

