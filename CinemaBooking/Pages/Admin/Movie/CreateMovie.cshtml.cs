
using CinemaBooking.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace CinemaBooking.Pages.Admin.Movie
{
    public class CreateMovieModel : PageModel
    {
        private readonly CinemaBookingContext _context;

        // List of selectable categories, directors, actors, and countries
        public List<Data.Category> Categories { get; set; }
        public List<SelectListItem> Directors { get; set; }
        public List<SelectListItem> Actors { get; set; }
        public List<string> Countries { get; set; }

        // Properties to store selected categories and actors
        [BindProperty]
        public List<int> CategoryIds { get; set; }

        [BindProperty]
        public List<int> ActorIds { get; set; } = new List<int>();

        // Other properties as needed
        [BindProperty]
        public Data.Movie Movie { get; set; }

        public CreateMovieModel(CinemaBookingContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            Categories = await _context.Categories.ToListAsync();

            Directors = await _context.Directors
                .Select(d => new SelectListItem { Value = d.DirectorId.ToString(), Text = d.DirectorName })
                .ToListAsync();

            Actors = await _context.Actors
                .Select(a => new SelectListItem { Value = a.ActorId.ToString(), Text = a.ActorName })
                .ToListAsync();

            // Read countries from the JSON file
            var jsonData = await System.IO.File.ReadAllTextAsync("wwwroot/data/countries.json");
            var countryList = JsonSerializer.Deserialize<List<Country>>(jsonData);
            Countries = countryList?.ConvertAll(c => c.CountryName);
        }

        public async Task<IActionResult> OnPostAsync(int[] ActorIds, int[] CategoryIds, IFormFile image, IFormFile imageBackground)
        {
            var newMovie = new Data.Movie
            {
                Title = Movie.Title,
                Length = Movie.Length,
                Description = Movie.Description,
                AgeLimit = Movie.AgeLimit,
                WarningText = Movie.WarningText,
                PublishTime = Movie.PublishTime,
                Country = Movie.Country,
                Status = Movie.Status,
                DirectorId = Movie.DirectorId,
                VideoTrailer = Movie.VideoTrailer
            };

            // Save main image
            if (image != null && image.Length > 0)
            {
                var imagePath = Path.Combine("wwwroot/images", image.FileName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }
                newMovie.Image = $"/images/{image.FileName}";
            }

            // Save background image
            if (imageBackground != null && imageBackground.Length > 0)
            {
                var bgImagePath = Path.Combine("wwwroot/images", imageBackground.FileName);
                using (var stream = new FileStream(bgImagePath, FileMode.Create))
                {
                    await imageBackground.CopyToAsync(stream);
                }
                newMovie.ImageBackground = $"/images/{imageBackground.FileName}";
            }
            Console.WriteLine("New Movie Details:");
            Console.WriteLine($"Title: {newMovie.Title}");
            Console.WriteLine($"Length: {newMovie.Length}");
            Console.WriteLine($"Description: {newMovie.Description}");
            Console.WriteLine($"AgeLimit: {newMovie.AgeLimit}");
            Console.WriteLine($"WarningText: {newMovie.WarningText}");
            Console.WriteLine($"PublishTime: {newMovie.PublishTime}");
            Console.WriteLine($"Country: {newMovie.Country}");
            Console.WriteLine($"Status: {newMovie.Status}");
            Console.WriteLine($"DirectorId: {newMovie.DirectorId}");
            Console.WriteLine($"VideoTrailer: {newMovie.VideoTrailer}");
            Console.WriteLine($"Image: {newMovie.Image}");
            Console.WriteLine($"ImageBackground: {newMovie.ImageBackground}");
            _context.Movies.Add(newMovie);
            await _context.SaveChangesAsync();
            Console.WriteLine("New Movie ID: " + newMovie.MovieId);


            // Assign categories
            foreach (var categoryId in CategoryIds)
            {
                var categoryAssignment = new MovieCategoryAssignment
                {
                    MovieId = newMovie.MovieId,
                    CategoryId = categoryId
                };
                _context.MovieCategoryAssignments.Add(categoryAssignment);
            }

            // Assign actors
            foreach (var actorId in ActorIds)
            {
                var actorAssignment = new ActorMovieAssignment
                {
                    MovieId = newMovie.MovieId,
                    ActorId = actorId
                };
                _context.ActorMovieAssignments.Add(actorAssignment);
            }

            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Movie saved successfully with ID: " + newMovie.MovieId;

            return RedirectToPage("/Admin/Movie/CreateMovie");
        }

        public async Task<IActionResult> OnPostAddCategory(string categoryName)
        {
            // Kiểm tra xem thể loại đã tồn tại chưa
            if (await _context.Categories.AnyAsync(c => c.CategoryName == categoryName))
            {
                ModelState.AddModelError(string.Empty, "Thể loại này đã tồn tại!"); // Thêm thông báo lỗi vào ModelState
                return Page();
            }

            var category = new Data.Category { CategoryName = categoryName };
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Thể loại đã được thêm thành công!";
            return RedirectToPage("/Admin/Movie/CreateMovie");
        }
        public async Task<IActionResult> OnPostAddActor(string actorName)
        {
            // Check if the actor already exists
            if (await _context.Actors.AnyAsync(a => a.ActorName == actorName))
            {
                ModelState.AddModelError(string.Empty, "This actor already exists!"); // Add error message to ModelState
                return Page();
            }

            var actor = new Data.Actor { ActorName = actorName };
            _context.Actors.Add(actor);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Actor added successfully!";
            return RedirectToPage("/Admin/Movie/CreateMovie");
        }

        public async Task<IActionResult> OnPostAddDirector(string directorName)
        {
            // Check if the director already exists
            if (await _context.Directors.AnyAsync(d => d.DirectorName == directorName))
            {
                ModelState.AddModelError(string.Empty, "This director already exists!"); // Add error message to ModelState
                return Page();
            }

            var director = new Data.Director { DirectorName = directorName };
            _context.Directors.Add(director);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Director added successfully!";
            return RedirectToPage("/Admin/Movie/CreateMovie");
        }

        public class Country
        {
            public string CountryCode { get; set; }
            public string CountryName { get; set; }
        }
    }
}

