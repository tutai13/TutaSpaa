using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using API.DTOs.Auth;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace API.Services
{
    public class SpeedSms
    {
        public const int TYPE_QC = 1;
        public const int TYPE_CSKH = 2;
        public const int TYPE_BRANDNAME = 3;
        public const int TYPE_BRANDNAME_NOTIFY = 4;
        public const int TYPE_GATEWAY = 5;

        private const string RootUrl = "https://api.speedsms.vn/index.php";

        private readonly HttpClient _client;
        private readonly string _accessToken;

        public SpeedSms(HttpClient client, IOptions<SpeedSmsSetting> settings)
        {
            _client = client;
            _accessToken = settings.Value.AccessToken;

            var authValue = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{_accessToken}:x"));
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authValue);
        }
        public async Task<string> GetUserInfoAsync()
        {
            var url = $"{RootUrl}/user/info";
            try
            {
                return await _client.GetStringAsync(url);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi phù hợp
                return $"Error: {ex.Message}";
            }
        }

        public async Task<string> SendSmsAsync(string phones, string content,  string sender = null, int type = 2 )
        {
            if (phones == null || phones.Length == 0) return "No phone numbers provided";
            if (string.IsNullOrEmpty(content)) return "Content is empty";
            if (type == TYPE_BRANDNAME && string.IsNullOrEmpty(sender)) return "Sender is required for brandname SMS";

            var url = $"{RootUrl}/sms/send";

            // Tạo đối tượng payload
            var payload = new
            {
                to = phones,
                content, 
                type,
                //sender = sender
            };

            var json = JsonConvert.SerializeObject(payload);

            try
            {
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _client.PostAsync(url, httpContent);
                response.EnsureSuccessStatusCode();

                Console.WriteLine(await response.Content.ReadAsStringAsync());
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return $"Error: {ex.Message}";
            }
        }

        public async Task<string> SendMmsAsync(string[] phones, string content, string link, string sender)
        {
            if (phones == null || phones.Length == 0) return "No phone numbers provided";
            if (string.IsNullOrEmpty(content)) return "Content is empty";

            var url = $"{RootUrl}/mms/send";

            var payload = new
            {
                to = phones,
                content,
                link,
                sender
            };

            var json = JsonConvert.SerializeObject(payload);

            try
            {
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _client.PostAsync(url, httpContent);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }
}
