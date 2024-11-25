namespace ESH.Zarinpal.DTO;

/// <summary>
/// مدل داده برای پاسخ موفقیت‌آمیز درخواست پرداخت.
/// </summary>
public class PaymentRequestResponseDto : object
{
    public PaymentRequestResponseDto() : base()
    {
    }
    
    /// <summary>
    /// کد یکتای تراکنش (Authority) برای پرداخت.
    /// </summary>
    public string Authority { get; set; }

    /// <summary>
    /// آدرس درگاه پرداخت.
    /// </summary>
    public string GatewayUrl { get; set; }
}