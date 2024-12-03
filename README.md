# ZarinPal Integration Library 🚀

کتابخانه‌ای برای ساده‌سازی ارتباط با درگاه پرداخت زرین‌پال. این کتابخانه امکان ارسال درخواست پرداخت و تأیید پرداخت را به صورت امن و ساده فراهم می‌کند و از نسخه‌های **سندباکس** و **واقعی** پشتیبانی می‌کند.

---

## ✨ ویژگی‌های کلیدی

- 💳 **درخواست پرداخت**: ارسال درخواست پرداخت به زرین‌پال و دریافت اطلاعات مربوط به تراکنش.
- 🔐 **تأیید پرداخت**: بررسی وضعیت پرداخت پس از بازگشت کاربر از درگاه.
- 🛠️ **پشتیبانی از سندباکس**: امکان تست بدون نیاز به تراکنش واقعی.
- 🎯 **خروجی فلوعنت**: مدیریت آسان نتیجه‌ها با ساختار `ZarinPalResult<T>`.
- ⚠️ **مدیریت خطاها**: تشخیص و مدیریت خطاهای مرتبط با ارتباط با زرین‌پال.

---

## 🛠️ نصب و راه‌اندازی

1. مطمئن شوید که پروژه شما با **.NET 6 یا بالاتر** سازگار است.
2. کتابخانه را در پروژه خود کپی یا از طریق گیت اضافه کنید.
3. وابستگی‌های زیر باید در پروژه نصب شوند:

   ```bash
   dotnet add package Newtonsoft.Json
   ```

---

## 🛑 تنظیمات اولیه

### ساخت نمونه پیکربندی

```csharp
var zarinpal = new Configuration("Your-Merchant-ID", sandbox: true);
```

### پارامترهای پیکربندی

- **MerchantID**: شناسه مرچنت شما از زرین‌پال.
- **sandbox**: حالت تست یا واقعی. مقدار پیش‌فرض `true` است.
- **email** و **mobile**: ایمیل و شماره تماس اختیاری برای تراکنش‌ها.

---

## 🧑‍💻 استفاده

### 💸 درخواست پرداخت

```csharp
var paymentRequest = new PaymentRequestDto
{
    CallbackUrl = "https://yourdomain.com/callback",
    Amount = 10000, // مبلغ به ریال
    Description = "خرید محصول",
    Email = "user@example.com",
    Mobile = "09123456789"
};

var result = await zarinpal.PaymentRequestAsync(paymentRequest);

if (result.IsSuccess)
{
    Console.WriteLine($"Authority: {((PaymentRequestResponseDto)result.Data).Authority}");
    Console.WriteLine($"Payment Gateway URL: {((PaymentRequestResponseDto)result.Data).GatewayUrl}");
}
else
{
    Console.WriteLine($"Error: {result.Message}");
}
```

### ✅ تأیید پرداخت

```csharp
var authority = "AUTHORITY_FROM_CALLBACK";
var amount = 10000;

var verificationResult = await zarinpal.PaymentVerificationAsync(authority, amount);

if (verificationResult.IsSuccess)
{
    Console.WriteLine($"Payment verified. RefID: {((PaymentVerificationSuccessDTO)verificationResult.Data).RefID}");
}
else
{
    Console.WriteLine($"Verification failed: {verificationResult.Message}");
}
```

---

## 📦 ساختار خروجی

### ✅ موفقیت‌آمیز

خروجی موفق همیشه شامل **Status** و **Data** خواهد بود.

```json
{
  "IsSuccess": true,
  "Status": 100,
  "Message": "Payment request created successfully.",
  "Data": {
    "Authority": "123456",
    "GatewayUrl": "https://sandbox.zarinpal.com/pg/StartPay/123456"
  }
}
```

### ❌ خطا

در صورت خطا، جزئیات در بخش **Message** و **Errors** نمایش داده می‌شوند.

```json
{
  "IsSuccess": false,
  "Status": -1,
  "Message": "Payment verification failed.",
  "Data": {
    "Authority": "123456",
    "Errors": {
      "Amount": ["Amount must be at least 100."]
    }
  }
}
```

---

## 🤝 همکاری

اگر می‌خواهید در توسعه این کتابخانه مشارکت کنید:

1. 🍴 **فورک کنید** پروژه را.
2. تغییرات خود را اعمال کرده و تست کنید.
3. ✉️ **Pull Request** ایجاد کنید.

---

## 📜 لایسنس

این پروژه تحت لایسنس MIT منتشر شده است. می‌توانید به صورت آزادانه از آن استفاده کنید. 🎉

---

🌟 **استفاده کنید، لذت ببرید و بازخورد دهید!**
