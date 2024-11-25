namespace ESH.Zarinpal.ZarinpalResponse;

public class ZarinpalVerificationSuccessResponse : object
{
    public ZarinpalVerificationSuccessResponse() : base()
    {
    }
    
    public int Status { get; set; }
    public string RefID { get; set; }
    public string Authority { get; set; }
}
