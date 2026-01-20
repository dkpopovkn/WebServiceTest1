namespace WebServiceTest1.Data;

public class RequestData
{
    public int Id { get; set; }
    public string? Headers { get; set; }
    public string? QueryParameters { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}