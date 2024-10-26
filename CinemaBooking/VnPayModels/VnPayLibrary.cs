using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace CinemaBooking.VnPayModels;


    public class VnPayLibrary
    {
        private readonly Dictionary<string, string> _requestData;

        public VnPayLibrary(Dictionary<string, string> requestData)
        {
            _requestData = requestData;
        }

        private string HmacSHA512(string key, string inputData)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key), "Key cannot be null or empty.");

            if (string.IsNullOrEmpty(inputData))
                throw new ArgumentNullException(nameof(inputData), "Input data cannot be null or empty.");

            using var hash = new HMACSHA512(Encoding.UTF8.GetBytes(key));
            var hashBytes = hash.ComputeHash(Encoding.UTF8.GetBytes(inputData));
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }


        public string CreateRequestUrl(string baseUrl, string hashSecret)
        {
            if (string.IsNullOrEmpty(baseUrl))
                throw new ArgumentNullException(nameof(baseUrl), "Base URL cannot be null or empty.");

            if (string.IsNullOrEmpty(hashSecret))
                throw new ArgumentNullException(nameof(hashSecret), "Hash secret cannot be null or empty.");

            var queryString = new StringBuilder();
            foreach (var kv in _requestData)
            {
                queryString.Append(HttpUtility.UrlEncode(kv.Key) + "=" + HttpUtility.UrlEncode(kv.Value) + "&");
            }

            string rawData = queryString.ToString().TrimEnd('&');

            // Kiểm tra xem rawData có rỗng không
            if (string.IsNullOrEmpty(rawData))
                throw new ArgumentNullException(nameof(rawData), "Raw data cannot be null or empty.");

            string vnpSecureHash = HmacSHA512(hashSecret, rawData);
            return $"{baseUrl}?{rawData}&vnp_SecureHash={vnpSecureHash}";
        }
    }
