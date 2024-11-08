using CinemaBooking.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace CinemaBooking.Pages.Admin.Movie
{
    [Authorize(Roles = "Admin")]
    public class UpdateMovieModel : PageModel
    {
        private readonly CinemaBookingContext _context;

        public List<Data.Category> Categories { get; set; }
        public List<SelectListItem> Directors { get; set; }
        public List<SelectListItem> Actors { get; set; }
        public List<string> Countries { get; set; }

        [BindProperty]
        public Data.Movie Movie { get; set; }

        [BindProperty]
        public List<int> CategoryIds { get; set; } = new List<int>();

        [BindProperty]
        public List<int> ActorIds { get; set; } = new List<int>();

        [BindProperty]
        public IFormFile Image { get; set; }

        [BindProperty]
        public IFormFile ImageBackground { get; set; }

        public UpdateMovieModel(CinemaBookingContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Movie = await _context.Movies
                .Include(m => m.MovieCategoryAssignments)
                .Include(m => m.ActorMovieAssignments)
                .FirstOrDefaultAsync(m => m.MovieId == id);

            if (Movie == null)
            {
                return NotFound();
            }

            // Load Categories, Directors, and Actors for the dropdowns
            Categories = await _context.Categories.ToListAsync() ?? new List<Data.Category>(); // Initialize as an empty list if null
            Directors = await _context.Directors
                .Select(d => new SelectListItem { Value = d.DirectorId.ToString(), Text = d.DirectorName })
                .ToListAsync();
            Actors = await _context.Actors
                .Select(a => new SelectListItem { Value = a.ActorId.ToString(), Text = a.ActorName })
                .ToListAsync();

            // Populate CategoryIds and ActorIds for existing associations
            CategoryIds = Movie.MovieCategoryAssignments.Select(a => a.CategoryId).ToList();
            ActorIds = Movie.ActorMovieAssignments.Select(a => a.ActorId).ToList();

            return Page();
        }


        public async Task<IActionResult> OnPostAsync(int id)
        {
            //if (!ModelState.IsValid) return Page();

            var movieToUpdate = await _context.Movies
                .Include(m => m.MovieCategoryAssignments)
                .Include(m => m.ActorMovieAssignments)
                .FirstOrDefaultAsync(m => m.MovieId == id);

            if (movieToUpdate == null) return NotFound();

            movieToUpdate.Title = Movie.Title;
            movieToUpdate.Length = Movie.Length;
            movieToUpdate.Description = Movie.Description;
            movieToUpdate.AgeLimit = Movie.AgeLimit;
            movieToUpdate.WarningText = Movie.WarningText;
            movieToUpdate.PublishTime = Movie.PublishTime;
            movieToUpdate.Country = Movie.Country;
            movieToUpdate.Status = Movie.Status;
            movieToUpdate.DirectorId = Movie.DirectorId;
            movieToUpdate.VideoTrailer = Movie.VideoTrailer;

            Console.WriteLine("Updated Movie Values:");
            Console.WriteLine($"Title: {movieToUpdate.Title}");
            Console.WriteLine($"Length: {movieToUpdate.Length}");
            Console.WriteLine($"Description: {movieToUpdate.Description}");
            Console.WriteLine($"AgeLimit: {movieToUpdate.AgeLimit}");
            Console.WriteLine($"WarningText: {movieToUpdate.WarningText}");
            Console.WriteLine($"PublishTime: {movieToUpdate.PublishTime}");
            Console.WriteLine($"Country: {movieToUpdate.Country}");
            Console.WriteLine($"Status: {movieToUpdate.Status}");
            Console.WriteLine($"DirectorId: {movieToUpdate.DirectorId}");
            Console.WriteLine($"VideoTrailer: {movieToUpdate.VideoTrailer}");
            // Save image if uploaded
            if (Image != null && Image.Length > 0)
            {
                var imagePath = Path.Combine("wwwroot/images", Image.FileName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await Image.CopyToAsync(stream);
                }
                movieToUpdate.Image = $"/images/{Image.FileName}";
            }

            // Save background image if uploaded
            if (ImageBackground != null && ImageBackground.Length > 0)
            {
                var bgImagePath = Path.Combine("wwwroot/images", ImageBackground.FileName);
                using (var stream = new FileStream(bgImagePath, FileMode.Create))
                {
                    await ImageBackground.CopyToAsync(stream);
                }
                movieToUpdate.ImageBackground = $"/images/{ImageBackground.FileName}";
            }

            // Update Category and Actor assignments
            await UpdateCategoriesAndActors(id);

            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Movie updated successfully!";

            return RedirectToPage("/Admin/Movie/ListMovie");
        }

        private async Task UpdateCategoriesAndActors(int movieId)
        {
            await _context.Database.ExecuteSqlRawAsync("DELETE FROM MovieCategoryAssignments WHERE MovieId = {0}", movieId);

            // Insert new MovieCategoryAssignments
            foreach (var categoryId in CategoryIds)
            {
                await _context.Database.ExecuteSqlRawAsync(
                    "INSERT INTO MovieCategoryAssignments (MovieId, CategoryId) VALUES ({0}, {1})", movieId, categoryId);
            }

            // Delete existing ActorMovieAssignments
            await _context.Database.ExecuteSqlRawAsync("DELETE FROM ActorMovieAssignments WHERE MovieId = {0}", movieId);

            // Insert new ActorMovieAssignments
            foreach (var actorId in ActorIds)
            {
                await _context.Database.ExecuteSqlRawAsync(
                    "INSERT INTO ActorMovieAssignments (MovieId, ActorId) VALUES ({0}, {1})", movieId, actorId);
            }
        }

        
    }
}
