using CinemaBooking.Repositories.Post;
using CinemaBooking.Services;
using CinemaBooking.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaBooking.Pages.Admin.Post;
[Authorize(Roles = "Admin")]
public class ListModel : PageModel
{
    private readonly AdminPostService _adminPostService;

    public List<PostDto> Posts { get; set; }

    [BindProperty(SupportsGet = true)]
    public string Title { get; set; }

    [BindProperty(SupportsGet = true)]
    public string Status { get; set; }

    [BindProperty(SupportsGet = true)]
    public DateTime? FromDate { get; set; }

    [BindProperty(SupportsGet = true)]
    public DateTime? ToDate { get; set; }

    [TempData]
    public string SuccessMessage { get; set; }

    [TempData]
    public string ErrorMessage { get; set; }

    public ListModel(AdminPostService adminPostService)
    {
        _adminPostService = adminPostService;
    }

    public async Task OnGetAsync()
    {
        Posts = await _adminPostService.GetAllPostsAsync(Title, Status, FromDate, ToDate);
    }

    public async Task<IActionResult> OnPostHideAsync(int postId)
    {
        var result = await _adminPostService.HidePostAsync(postId);

        if (result)
        {
            SuccessMessage = "Post has been hidden successfully.";
        }
        else
        {
            ErrorMessage = "Failed to hide the post.";
        }

        return RedirectToPage();
    }
}
