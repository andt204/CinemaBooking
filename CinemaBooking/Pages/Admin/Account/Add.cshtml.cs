using CinemaBooking.Data;
using CinemaBooking.Repositories;
using CinemaBooking.Repositories.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CinemaBooking.Pages.Admin.Account;

public class Add : PageModel
{
    private readonly IAccountRepository _accountRepository;
    private readonly IRoleRepository _roleRepository;

    public Add(IAccountRepository accountRepository, IRoleRepository roleRepository)
    {
        _accountRepository = accountRepository;
        _roleRepository = roleRepository;
    }

    public IEnumerable<Role> Roles { get; set; }

   

    [BindProperty]
        public AccountViewModel Input { get; set; }

        public class AccountViewModel
        {
            public Data.Account Account { get; set; }
            public List<SelectListItem> Roles { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            // Lấy danh sách vai trò từ repository
            var roles = await _roleRepository.GetListAsync();

            Input = new AccountViewModel
            {
                Account = new Data.Account(),
                Roles = roles.Select(r => new SelectListItem
                {
                    Value = r.RoleId.ToString(),
                    Text = r.RoleName
                }).ToList()
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(IFormFile avatar)
        {
            if (!ModelState.IsValid)
            {
                // Tải lại danh sách vai trò trong trường hợp có lỗi
                var roles = await _roleRepository.GetListAsync();
                Input.Roles = roles.Select(r => new SelectListItem
                {
                    Value = r.RoleId.ToString(),
                    Text = r.RoleName
                }).ToList();

                return Page();
            }

          

            return RedirectToPage("/Admin/Account/List"); // Chuyển hướng về trang danh sách sau khi tạo thành công
        }
    
}