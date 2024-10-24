using System.IdentityModel.Tokens.Jwt;

namespace CinemaBooking.Helper
{
    public class DecodeJwtToken
    {
        public static string DecodeJwtTokenAndGetEmail(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            // Kiểm tra token có hợp lệ và có thể giải mã không
            if (tokenHandler.CanReadToken(token))
            {
                var jwtToken = tokenHandler.ReadJwtToken(token);

                // Tìm claim với tên "email" và lấy giá trị của nó
                var emailClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "AccountId");

                if (emailClaim != null)
                {
                    return emailClaim.Value; // Trả về giá trị email
                }
            }

            // Nếu không tìm thấy email hoặc token không hợp lệ
            return null;
        }
    }
}
