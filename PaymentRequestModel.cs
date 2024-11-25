namespace ESH.Zarinpal;

/// <summary>
/// مدل کنترل درگاه پرداخت
/// </summary>
/// <param name="amount">مبلغ</param>
/// <param name="callbackUrl">آدرسی که از درگاه باید به آن برگشت</param>
/// <param name="description">توضیحات درگاه</param>
public class PaymentRequestModel(int amount, string callbackUrl, string description) : object
{
    /// <summary>
    /// مبلغ
    /// </summary>
    public int Amount { get; set; } = amount;

    /// <summary>
    /// صفحه برگشت از درگاه
    /// </summary>
    public string CallbackUrl { get; set; } = callbackUrl;
    
    /// <summary>
    /// توضیحاتی که باید در درگاه بانکی نمایش دهیم
    /// </summary>
    public string Description { get; set; } = description;
}