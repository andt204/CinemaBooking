using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CinemaBooking.Pages.Customer
{
    public class BasePageCustomerModel : PageModel
    {
        public string AccountId { get; private set; }
        public string Email { get; private set; }
        public string Role { get; private set; }

        protected void LoadUserClaims()
        {
            // Get the JWT token from the cookies
            var token = HttpContext.Request.Cookies["jwtToken"];
            if (!string.IsNullOrEmpty(token))
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

                if (jwtToken != null)
                {
                    AccountId = jwtToken.Claims.FirstOrDefault(c => c.Type == "AccountId")?.Value;
                    Email = jwtToken.Claims.FirstOrDefault(c => c.Type == "Email")?.Value;
                    Role = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
                }
            }
        }
    }
}
