namespace API.DTOs.Auth
{
    public class OtpResponse
    {
        public string Status { get; set; }
        public string Code { get; set; }
        public SmsData Data { get; set; }
    }

    public class SmsData
    {
        public long TranId { get; set; }
        public int TotalSMS { get; set; }
        public int TotalPrice { get; set; }
        public List<string> InvalidPhone { get; set; }
    }
}
