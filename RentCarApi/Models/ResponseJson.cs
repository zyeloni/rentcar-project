namespace RentCarApi.Models;

public class ResponseJson
{
    public StatusCode Status { get; set; }
    public String Message { get; set; }
    
    public enum StatusCode
    {
        Ok,
        NoOk
    }
}