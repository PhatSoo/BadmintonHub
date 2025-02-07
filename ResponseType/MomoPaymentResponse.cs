namespace BadmintonHub.ResponseType
{
    public class MomoPaymentResponse
    {
        public string PartnerCode { get; set; } = String.Empty;
        public string OrderId { get; set; } = String.Empty;
        public string RequestId { get; set; } = String.Empty;
        public  int Amount { get; set; }
        public  long ResponseTime { get; set; }
        public string Message { get; set; } = String.Empty;
        public  int ResultCode { get; set; }
        public string PayUrl { get; set; } = String.Empty;
        public string Deeplink { get; set; } = String.Empty;
        public string QrCodeUrl { get; set; } = String.Empty;
    }
}
