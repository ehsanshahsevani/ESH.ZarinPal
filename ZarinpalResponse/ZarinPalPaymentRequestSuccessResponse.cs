namespace ESH.Zarinpal.ZarinpalResponse;

/// <summary>
/// مدل برای درخواست پرداخت موفق
/// </summary>
public class ZarinPalPaymentRequestSuccessResponse : object
{
    public ZarinPalPaymentRequestSuccessResponse() : base()
    {
    }
    
    /// <summary>
    /// وضعیت
    /// </summary>
    public int Status { get; set; }
    
    /// <summary>
    /// کد آتوریتی ذرین پال
    /// </summary>
    public string Authority { get; set; }

    public string GatewayUrl { get; set; }
}