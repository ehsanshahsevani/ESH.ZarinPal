namespace ESH.Zarinpal.DTO;

/// <summary>
/// DTO برای ایجاد درخواست پرداخت در زرین‌پال.
/// </summary>
public class PaymentRequestDto : object
{
    /// <summary>
    /// سازنده پیش‌فرض.
    /// </summary>
    public PaymentRequestDto()
    {
    }

    /// <summary>
    /// سازنده کامل برای مقداردهی اولیه به درخواست پرداخت.
    /// </summary>
    /// <param name="callbackUrl">آدرس بازگشتی که نتیجه پرداخت به آن ارسال می‌شود.</param>
    /// <param name="amount">مبلغ پرداخت (به ریال).</param>
    /// <param name="description">توضیحات مربوط به تراکنش پرداخت.</param>
    /// <param name="email">ایمیل اختیاری پرداخت‌کننده.</param>
    /// <param name="mobile">شماره موبایل اختیاری پرداخت‌کننده.</param>
    public PaymentRequestDto(string callbackUrl, int amount, string description, string email = null, string mobile = null)
    {
        CallbackUrl = callbackUrl;
        Amount = amount;
        Description = description;
        Email = email;
        Mobile = mobile;
    }
    
    /// <summary>
    /// آدرس بازگشتی که نتیجه پرداخت به آن ارسال می‌شود.
    /// </summary>
    public string CallbackUrl { get; set; }

    /// <summary>
    /// مبلغ پرداخت (به ریال).
    /// </summary>
    public int Amount { get; set; }

    /// <summary>
    /// توضیحات مربوط به تراکنش پرداخت.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// ایمیل اختیاری پرداخت‌کننده.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// شماره موبایل اختیاری پرداخت‌کننده.
    /// </summary>
    public string Mobile { get; set; }
}
