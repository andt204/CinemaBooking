using CinemaBooking.Repositories.Post;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaBooking.Pages.Admin.Post;

public class List : PageModel
{
    private readonly IPostRepository _postRepository;
    public List(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }
    public IEnumerable<Data.Account> Accounts { get; set; }

    public void OnGet()
    {
        
    }
}