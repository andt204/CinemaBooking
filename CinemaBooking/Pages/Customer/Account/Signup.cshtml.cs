using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CinemaBooking;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using CinemaBooking.Repositories;
using Microsoft.Extensions.Logging;
using System;
using CinemaBooking.Repositories.Role;
using CinemaBooking.Data;
namespace CinemaBooking.Pages.Customer.Account
{
    public class SignupModel : PageModel
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly ILogger<SignupModel> _logger;
        private readonly CinemaBookingContext _context;
    
        [BindProperty]
        public string messageSuccess { get; set; }
        public SignupModel(IAccountRepository accountRepository, ILogger<SignupModel> logger, CinemaBookingContext context, IRoleRepository roleRepository)
        {

            _accountRepository = accountRepository;
            _logger = logger;
            _context = context;
            _roleRepository = roleRepository;
        }

        [BindProperty]
        public Data.Account Account { get; set; }

        public void OnGet()
        {
            _logger.LogInformation("OnGet method called.");
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync()
        {
            _logger.LogInformation("OnPostAsync method called.");

            // Thiết lập giá trị cho Account.Role trước khi kiểm tra ModelState
            Account.Role = _context.Roles.FirstOrDefault(x => x.RoleId == 1);

            // Kiểm tra xem Role có tồn tại hay không
            if (Account.Role == null)
            {
                _logger.LogWarning("Role with RoleId 1 not found.");
                ModelState.AddModelError("Account.Role", "The specified role does not exist.");
                return Page();
            }

            // Nếu ModelState đã có lỗi của Role trước đó, bạn cần loại bỏ và thiết lập lại
            if (ModelState.ContainsKey("Account.Role"))
            {
                ModelState.Remove("Account.Role");
            }
            if (ModelState.ContainsKey("messageSuccess"))
            {
                ModelState.Remove("messageSuccess");
            }

            var existingAccountByEmail = await _context.Accounts.FirstOrDefaultAsync(a => a.Email == Account.Email);
            if (existingAccountByEmail != null)
            {
                _logger.LogWarning("Email already exists: {Email}", Account.Email);
                ModelState.AddModelError("Account.Email", "The email address is already registered.");
            }

            // Kiểm tra xem số điện thoại có tồn tại trong hệ thống không
            var existingAccountByPhone = await _context.Accounts.FirstOrDefaultAsync(a => a.PhoneNumber == Account.PhoneNumber);
            if (existingAccountByPhone != null)
            {
                _logger.LogWarning("Phone number already exists: {PhoneNumber}", Account.PhoneNumber);
                ModelState.AddModelError("Account.PhoneNumber", "The phone number is already registered.");
            }
            string password =Account.Password;
            // Kiểm tra ModelState sau khi Role đã được thiết lập
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Model state is invalid. Detailed validation errors:");

                foreach (var modelStateKey in ModelState.Keys)
                {
                    var value = ModelState[modelStateKey];
                    foreach (var error in value.Errors)
                    {
                        _logger.LogWarning($"Field '{modelStateKey}': {error.ErrorMessage}");
                    }
                }

                return Page();
            }

            try
            {
                var roles = await _roleRepository.GetListAsync();
                // Thiết lập các thuộc tính của Account
                Account.Status = 1;
                // Thiết lập RoleId thay vì thiết lập Role trực tiếp
                Account.Password = BCrypt.Net.BCrypt.HashPassword(password);
                Account.Role = roles.FirstOrDefault(x => x.RoleId ==2);
                await _accountRepository.CreateAsync(Account);

                _logger.LogInformation("Account successfully added.");
                messageSuccess = "Register Successfully";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding account.");
                ModelState.AddModelError(string.Empty, "An error occurred while adding account.");
            }

            return Page();
        }

    }
}
