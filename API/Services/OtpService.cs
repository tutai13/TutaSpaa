using API.DTOs.Auth;
using API.IService;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace API.Services
{
    public class OtpService : IOTPService
    {

        private readonly SpeedSms _sms;

        public OtpService(SpeedSms sms)
        {
            _sms = sms;
        }

        public async Task<OtpResponse> SendAsync(string phoneNumber)
        {

            Console.WriteLine("aloooo");
            var otp = GenerateOTP();

            var json = await _sms.SendSmsAsync(phoneNumber, $"Your OTP is : {otp}");

            var response = JsonSerializer.Deserialize<OtpResponse>(json);


            return response; 
             
        }

        public Task<bool> VerificationAsync(string phoneNumber, string Otp)
        {
            throw new NotImplementedException();
        }

        private string GenerateOTP()
        {

            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var rd = new Random();
            return new string(Enumerable.Repeat(chars, 6).Select(s => s[rd.Next(chars.Length)]).ToArray()); ;

        }
    }
}
