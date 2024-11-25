namespace ESH.Zarinpal.DTO;

/// <summary>
/// مدل پاسخ موفق
/// </summary>
public class PaymentVerificationSuccessDTO: object
{
    public PaymentVerificationSuccessDTO() : base()
    {
    }
    
    public string RefID { get; set; }
    
    public string Authority { get; set; }
}