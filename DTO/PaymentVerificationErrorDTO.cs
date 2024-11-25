namespace ESH.Zarinpal.DTO;

/// <summary>
/// مدل پاسخ خطا
/// </summary>
public class PaymentVerificationErrorDTO : object
{
    public PaymentVerificationErrorDTO() : base()
    {
    }

    public string Authority { get; set; }
    
    public Dictionary<string, List<string>> Errors { get; set; }
}