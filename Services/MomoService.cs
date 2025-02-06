using Azure.Core;
using BadmintonHub.Databases;
using BadmintonHub.Mappings;
using BadmintonHub.Services.Interfaces;
using Microsoft.Extensions.Options;
using System.Net;
using System.Security.Cryptography;
using System.Text;

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

        public async Task<string?> PaymentBookingAsync(Guid bookingId, long amount)
        {
            string rawHash = $"accessKey={_options.Value.AccessKey}" +
                    $"&amount={amount}" +
                    $"&orderId={bookingId}" +
                    $"&requestId={bookingId}" +
                    $"&orderInfo=Orderinfo" +
                    $"&notifyUrl={_options.Value.NotifyUrl}" +
                    $"&partnerCode={_options.Value.PartnerCode}" +
                    $"&returnUrl={_options.Value.ReturnUrl}";

            var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(_options.Value.SecretKey));
            var signature = BitConverter.ToString(hmac.ComputeHash(Encoding.UTF8.GetBytes(rawHash))).Replace("-", "").ToLower();

            var requestData = new
            {
                accessKey = _options.Value.AccessKey,
                requestType = _options.Value.RequestType,
                amount = amount.ToString(),
                orderId = bookingId.ToString(),
                partnerCode = _options.Value.PartnerCode,
                returnUrl = _options.Value.ReturnUrl,
                notifyUrl = _options.Value.NotifyUrl,
                requestId = bookingId.ToString(),
                signature = signature
            };


            var response = await _httpClient.PostAsJsonAsync(_options.Value.MomoApiUrl, requestData);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            return jsonResponse;
        }
    }
}
