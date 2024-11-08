using CinemaBooking.Data;
using CinemaBooking.Repositories.SeatType;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CinemaBooking.Pages.Admin.SeatType;

public class List : PageModel
{
    private readonly CinemaBookingContext _context;

    public List(CinemaBookingContext context)
    {
        _context = context;
    }
[BindProperty]
    public List<Data.SeatType> SeatTypes { get; set; }
    [BindProperty]
    public Data.SeatType SeatType { get; set; }
    public string ErrorMessage { get;  set; }


    public void OnGet(string? name)
    {
        if (!string.IsNullOrEmpty(name))
        {
            SeatTypes = _context.SeatTypes.Where(s => s.SeatTypeName.Contains(name)).ToList();
        }
        else
        {
            SeatTypes = _context.SeatTypes.ToList();
        }

      
    }
    public async Task<IActionResult> OnPostAsync( )
    {
        Console.WriteLine("vcl0");
        // Check ModelState first
        // if (!ModelState.IsValid)
        //     return Page();

        // Check if the actor already exists
        if (await _context.SeatTypes.AnyAsync(a => a.SeatTypeName == SeatType.SeatTypeName))
        {
            TempData["ErrorMessage"] = "This name already exists!"; // Add error message to ModelState
            return RedirectToPage();
        }

        var seat = new Data.SeatType
        {
            SeatTypeName = SeatType.SeatTypeName,
            SeatPrice = SeatType.SeatPrice
        };
        _context.SeatTypes.Add(seat);
        await _context.SaveChangesAsync();

        TempData["SuccessMessage"] = "Price has been successfully added!";
        return RedirectToPage();
    }

    public async Task<IActionResult> UpdateSeatTypeOnPostAsync(int? id)
    {
        Console.WriteLine("vcl");
        var existingSeatType = await _context.SeatTypes.FindAsync(id);
        if (existingSeatType == null)
        {
            TempData["ErrorMessage"] = "Seat type not found!";
            return RedirectToPage();
        }

        // Validate if the SeatTypeName is unique (excluding the current record)
        if (await _context.SeatTypes.AnyAsync(a => (a.SeatTypeName == SeatType.SeatTypeName && a.SeatTypeId != id)))
        {
            TempData["ErrorMessage"] = "This name already exists!";
            return RedirectToPage();
        }

        // Update fields with new values
        existingSeatType.SeatTypeName = SeatType.SeatTypeName;
        existingSeatType.SeatPrice = SeatType.SeatPrice;

        _context.SeatTypes.Update(existingSeatType);
        await _context.SaveChangesAsync();

        TempData["SuccessMessage"] = "Seat type updated successfully!";
        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostDeleteAsync(int? id)
    {
        Console.WriteLine("vcl1");
        var existingSeatType = await _context.SeatTypes.FindAsync(id);
        if (existingSeatType == null)
        {
            TempData["ErrorMessage"] = "Seat type not found!";
            return RedirectToPage();
        }
        _context.SeatTypes.Remove(existingSeatType);
        await _context.SaveChangesAsync();

        TempData["SuccessMessage"] = "Seat type deleted successfully!";
        return RedirectToPage();
    }
}