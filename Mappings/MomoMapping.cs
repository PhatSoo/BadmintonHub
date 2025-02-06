namespace BadmintonHub.Mappings
{
    public class MomoMapping
    {
        public required string MomoApiUrl { get; set; }
        public required string SecretKey {get;set;}
        public required string AccessKey {get;set;}
        public required string ReturnUrl {get;set;}
        public required string NotifyUrl {get;set;}
        public required string PartnerCode {get;set;}
        public required string RequestType {get;set;}
    }
}
