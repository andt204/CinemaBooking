using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CinemaBooking.Data;
using CinemaBooking.Helper;

namespace CinemaBooking.Pages.Customer.Account
{
    public class LoginModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly CinemaBookingContext _context;

        [BindProperty]
        public Data.Account account { get; set; }
        [BindProperty]
        public string messageForEmail { get; set; }
        [BindProperty]
        public string messageForPasword { get; set; }
        public LoginModel(IConfiguration configuration, CinemaBookingContext context)
        {
            _configuration = configuration;
            _context = context;
        }



        [ValidateAntiForgeryToken]
        public IActionResult OnPost(string Email, string Password)
        {
            var account = _context.Accounts.FirstOrDefault(x => x.Email == Email);

            if (account == null)
            {
                messageForEmail = "Email does not exist.";
                // Nếu email không tồn tại

                return Page();
            }
            else
            {
                // Kiểm tra mật khẩu có đúng không
                if (!BCrypt.Net.BCrypt.Verify(Password, account.Password))
                {
                    messageForPasword = "Password is not corrrect";
                    return Page();
                }
                else
                {
                    //Tạo JWT token
                    var token = GenerateJwtToken(account);

                    Response.Cookies.Append("jwtToken", token, new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                          SameSite = SameSiteMode.Lax,
                        Expires = DateTimeOffset.UtcNow.AddMinutes(60)
                    });

                    if (account.RoleId == 1)
                    {
                        return RedirectToPage("/Admin/Account/List");
                    }
                    return RedirectToPage("/Customer/Movie/List");
                }
            }
        }

        private string GenerateJwtToken(Data.Account account)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {   new Claim("AccountId", account.AccountId.ToString()),

                    new Claim("Email", account.Email),
                    new Claim(ClaimTypes.Role, account.RoleId == 1 ? "Admin" : "Customer")
                }),
                Expires = DateTime.UtcNow.AddMinutes(int.Parse(_configuration["Jwt:ExpiryInMinutes"])),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<ActionResult> OnGetAsync()
        {
            var token = Request.Cookies["jwtToken"];
            if (token != null)
            {
                var email = DecodeJwtToken.DecodeJwtTokenAndGetEmail(token);
                if (email != null)
                {
                    var account = _context.Accounts.FirstOrDefault(x => x.AccountId == Int32.Parse(email));
                    if (account != null)
                    {
                        if (account.RoleId == 1)
                        {
                            return RedirectToPage("/Admin/Account/List");
                        }
                        else
                        {
                            return RedirectToPage("/Customer/Movie/List");
                        }
                    }
                }
            }
            return await Task.FromResult(Page());
        }

    }
}
