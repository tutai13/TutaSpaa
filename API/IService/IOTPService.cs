using API.DTOs.Auth;

namespace API.IService
{
    public interface IOTPService
    {
        Task<OtpResponse> SendAsync(string phoneNumber);


        Task<bool> VerificationAsync(string phoneNumber, string Otp);


    }

}
