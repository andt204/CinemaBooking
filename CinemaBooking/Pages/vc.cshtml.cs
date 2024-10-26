using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaBooking.Pages;

public class vc : PageModel
{
    private readonly ILogger<vc> _logger;

    public vc(ILogger<vc> logger)
    {
        _logger = logger;
    }
    public void OnGet()
    {
        
    }
    [BindProperty] public int Amount { get; set; }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            // Kiểm tra các lỗi trong ModelState
            foreach (var state in ModelState)
            {
                _logger.LogError($"{state.Key}: {string.Join(", ", state.Value.Errors.Select(e => e.ErrorMessage))}");
            }

            return Page();
        }

        if (Amount <= 0)
        {
            ModelState.AddModelError(string.Empty, "Số tiền không hợp lệ");
            return Page();
        }

        return RedirectToPage("Logout");

    }
}