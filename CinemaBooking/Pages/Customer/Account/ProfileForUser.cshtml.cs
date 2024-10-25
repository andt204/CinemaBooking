using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CinemaBooking.Data;
using CinemaBooking.Helper;
using Microsoft.EntityFrameworkCore;
using CinemaBooking.Repositories.Role;
using CinemaBooking.Repositories;
namespace CinemaBooking.Pages.Customer.Account
{
    [Authorize(Roles = "Customer")]
    public class ProfileForUserModel : PageModel
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly ILogger<SignupModel> _logger;
        private readonly CinemaBookingContext _context;

        public ProfileForUserModel(IAccountRepository accountRepository, ILogger<SignupModel> logger, CinemaBookingContext context, IRoleRepository roleRepository)
        {

            _accountRepository = accountRepository;
            _logger = logger;
            _context = context;
            _roleRepository = roleRepository;
        }

        [BindProperty]
        public Data.Account account { get; set; }
        public string messageSuccess { get; set; }
        public void OnGet()
        {

            var token = Request.Cookies["jwtToken"];
            if (token != null)
            {
                var email = DecodeJwtToken.DecodeJwtTokenAndGetEmail(token);
                if (email != null)
                {
                    account = _context.Accounts.FirstOrDefault(x => x.AccountId == Int32.Parse(email));
                    ViewData["Account"] = account; // Truyền dữ liệu account vào ViewData
                }
            }
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync()
        {

            var existingAccount = await _context.Accounts.FindAsync(account.AccountId);

            // Kiểm tra xem Role có tồn tại hay không
            if (ModelState.ContainsKey("Account.Role"))
            {
                ModelState.Remove("Account.Role");
            }

            // Nếu ModelState đã có lỗi của Role trước đó, bạn cần loại bỏ và thiết lập lại
            if (ModelState.ContainsKey("Account.Password"))
            {
                ModelState.Remove("Account.Password");
            }
            if (ModelState.ContainsKey("messageSuccess"))
            {
                ModelState.Remove("messageSuccess");
            }

            var existingAccountByEmail = await _context.Accounts.FirstOrDefaultAsync(a => a.Email == account.Email);
            if (existingAccountByEmail != null)
            {
                _logger.LogWarning("Email already exists: {Email}", account.Email);
                ModelState.AddModelError("Account.Email", "The email address is already registered.");
            }

            // Kiểm tra xem số điện thoại có tồn tại trong hệ thống không
            var existingAccountByPhone = await _context.Accounts.FirstOrDefaultAsync(a => a.PhoneNumber == account.PhoneNumber);
            if (existingAccountByPhone != null)
            {
                _logger.LogWarning("Phone number already exists: {PhoneNumber}", account.PhoneNumber);
                ModelState.AddModelError("Account.PhoneNumber", "The phone number is already registered.");
            }
            string password = account.Password;
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
                existingAccount.FullName = account.FullName;
                existingAccount.Gender = account.Gender;
                existingAccount.DateOfBirth = account.DateOfBirth;
                existingAccount.PhoneNumber = account.PhoneNumber;
                existingAccount.Email = account.Email;

                _context.Accounts.Update(existingAccount);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Account successfully added.");
                TempData["SuccessMessage"] = "Password changed successfully!";
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
