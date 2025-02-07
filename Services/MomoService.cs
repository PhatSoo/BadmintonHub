using Azure.Core;
using BadmintonHub.Databases;
using BadmintonHub.Mappings;
using BadmintonHub.ResponseType;
using BadmintonHub.Services.Interfaces;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace BadmintonHub.Services
{
    public class MomoService : IMomoService
    {
        private readonly IOptions<MomoMapping> _options;
        private readonly HttpClient _httpClient;

        public MomoService(IOptions<MomoMapping> options, HttpClient httpClient)
        {
            _options = options;
            _httpClient = httpClient;
        }

        public async Task<MomoPaymentResponse?> PaymentBookingAsync(Guid bookingId, long amount)
        {
            string orderId = bookingId.ToString("N") + "11";
            string requestId = Guid.NewGuid().ToString("N");

            string rawHash = $"accessKey={_options.Value.AccessKey}" +
                     $"&amount={amount}" +
                     $"&extraData=" +
                     $"&ipnUrl=https://webhook.site/b3088a6a-2d17-4f8d-a383-71389a6c600b" +
                     $"&orderId={orderId}" +
                     $"&orderInfo=Orderinfo" +
                     $"&partnerCode={_options.Value.PartnerCode}" +
                     $"&redirectUrl={_options.Value.ReturnUrl}" +
                     $"&requestId={requestId}" +
                     $"&requestType={_options.Value.RequestType}";

            var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(_options.Value.SecretKey));
            var signature = BitConverter.ToString(hmac.ComputeHash(Encoding.UTF8.GetBytes(rawHash))).Replace("-", "").ToLower();

            var requestData = new
            {
                accessKey = _options.Value.AccessKey,
                amount = amount.ToString(),
                extraData = "",
                ipnUrl = "https://webhook.site/b3088a6a-2d17-4f8d-a383-71389a6c600b",
                orderId = orderId,
                orderInfo = "Orderinfo",
                partnerCode = _options.Value.PartnerCode,
                redirectUrl = _options.Value.ReturnUrl,
                requestId = requestId,
                requestType = _options.Value.RequestType,
                signature = signature
            };

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var requestContent = new StringContent(JsonSerializer.Serialize(requestData), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(_options.Value.MomoApiUrl, requestContent);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<MomoPaymentResponse>(jsonResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
    }
}
