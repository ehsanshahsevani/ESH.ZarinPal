using ESH.Zarinpal.DTO;
using ESH.Zarinpal.ZarinpalResponse;
using Newtonsoft.Json;
namespace ESH.Zarinpal;

public class Configuration(string merchantId, bool sandbox = true, string email = null, string mobile = null)
{
    private readonly string _baseUrl = sandbox
        ? "https://sandbox.zarinpal.com/pg/rest/WebGate/PaymentRequest.json"
        : "https://www.zarinpal.com/pg/rest/WebGate/PaymentRequest.json";

    private string GetVerificationUrl()
    {
        return sandbox
            ? "https://sandbox.zarinpal.com/pg/rest/WebGate/PaymentVerification.json"
            : "https://www.zarinpal.com/pg/rest/WebGate/PaymentVerification.json";
    }
    
    public async Task<ZarinPalResult<object>> PaymentRequestAsync(PaymentRequestDto model)
    {
        var client = new HttpClient();

        string merchent = sandbox == false ? merchantId : Guid.NewGuid().ToString();
        
        var content = new FormUrlEncodedContent([
            new KeyValuePair<string, string>("MerchantID", merchent),
            new KeyValuePair<string, string>("CallbackURL", model.CallbackUrl),
            new KeyValuePair<string, string>("Amount", model.Amount.ToString()),
            new KeyValuePair<string, string>("Description", model.Description),
            new KeyValuePair<string, string>("Email", model.Email ?? ""),
            new KeyValuePair<string, string>("Mobile", model.Mobile ?? "")
        ]);

        HttpResponseMessage response =
            await client.PostAsync(_baseUrl, content);

        string responseString = await response.Content.ReadAsStringAsync();
        
        try
        {
            if (response.IsSuccessStatusCode)
            {
                var successResponse = JsonConvert.
                    DeserializeObject<ZarinPalPaymentRequestSuccessResponse>(responseString);

                return new ZarinPalResult<object>
                {
                    IsSuccess = true,
                    Status = successResponse.Status,
                    Message = "Payment request created successfully.",
                    
                    Data = new PaymentRequestResponseDto
                    {
                        Authority = successResponse.Authority,
                        GatewayUrl = $"{(sandbox ? "https://sandbox.zarinpal.com" : "https://www.zarinpal.com")}/pg/StartPay/{successResponse.Authority}"
                    }
                };
            }
            else
            {
                var errorResponse = JsonConvert
                    .DeserializeObject<ZarinpalErrorResponse>(responseString);

                return new ZarinPalResult<object>
                {
                    IsSuccess = false,
                    Status = errorResponse.Status,
                    Message = "Payment request creation failed.",
                    Data = new ZarinpalErrorResponse
                    {
                        Errors = errorResponse.Errors
                    }
                };
            }
        }
        catch (Exception ex)
        {
            // مدیریت خطای غیرمنتظره
            return new ZarinPalResult<object>
            {
                IsSuccess = false,
                Status = -1,
                Message = $"An unexpected error occurred: {ex.Message}",
                Data = null
            };
        }
    }

    public async Task<ZarinPalResult<object>> PaymentVerificationAsync(string authority, int amount)
    {
        string verificationUrl = GetVerificationUrl();

        var client = new HttpClient();
        var content = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("MerchantID", merchantId),
            new KeyValuePair<string, string>("Authority", authority),
            new KeyValuePair<string, string>("Amount", amount.ToString())
        });

        HttpResponseMessage response =
            await client.PostAsync(verificationUrl, content);
        
        string responseString =
            await response.Content.ReadAsStringAsync();

        try
        {
            // بررسی موفقیت درخواست
            if (response.IsSuccessStatusCode)
            {
                var successResponse =
                    JsonConvert.DeserializeObject<ZarinpalVerificationSuccessResponse>(responseString);
                
                return new ZarinPalResult<object>
                {
                    IsSuccess = true,
                    Status = successResponse.Status,
                    Message = "Payment verified successfully.",
                    Data = new PaymentVerificationSuccessDTO
                    {
                        RefID = successResponse.RefID,
                        Authority = authority
                    }
                };
            }
            else
            {
                // بررسی خطا
                var errorResponse = Newtonsoft.Json.JsonConvert
                    .DeserializeObject<ZarinpalErrorResponse>(responseString);
                
                return new ZarinPalResult<object>()
                {
                    IsSuccess = false,
                    Message = "Payment verification failed.",
                    Data = new PaymentVerificationErrorDTO
                    {
                        Authority = authority,
                        Errors = errorResponse.Errors
                    },
                    Status = errorResponse.Status
                };
            }
        }
        catch (Exception ex)
        {
            // مدیریت خطاهای تجزیه یا غیرمنتظره
            return new ZarinPalResult<object>()
            {
                IsSuccess = false,
                Message = $"Unexpected error: {ex.Message}",
                Data = null,
                Status = -1
            };
        }
    }
}