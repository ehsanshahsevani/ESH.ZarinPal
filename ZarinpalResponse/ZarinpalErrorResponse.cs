namespace ESH.Zarinpal.ZarinpalResponse;

public class ZarinpalErrorResponse : object
{
    public ZarinpalErrorResponse()
    {
    }
    
    public int Status { get; set; }
    public Dictionary<string, List<string>> Errors { get; set; }
}