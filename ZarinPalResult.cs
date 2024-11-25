namespace ESH.Zarinpal;

public class ZarinPalResult<T> : object
{
    public ZarinPalResult() : base()
    {
    }
    
    /// <summary>
    /// نشان دهنده موفقیت یا خطا
    /// </summary>
    public bool IsSuccess { get; set; }
    
    /// <summary>
    /// پیام مربوط به نتیجه
    /// </summary>
    public string Message { get; set; }
    
    /// <summary>
    /// داده‌های برگشتی (پاسخ موفق یا خطا)
    /// </summary>
    public T Data { get; set; }
    
    /// <summary>
    /// کد وضعیت برگشتی از ذرین پال
    /// </summary>
    public int Status { get; set; }
}