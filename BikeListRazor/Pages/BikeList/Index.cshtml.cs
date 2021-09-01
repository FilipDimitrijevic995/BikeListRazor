using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BikeListRazor.Pages.BikeList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Bike> Bikes { get; set; }
        public async Task OnGet()
        {
            Bikes = await _db.Bike.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var bike = await _db.Bike.FindAsync(id);
            if (bike == null)
            {
                return NotFound();
            }
            _db.Bike.Remove(bike);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
