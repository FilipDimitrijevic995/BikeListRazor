using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BikeListRazor.Pages.BikeList
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Bike Bike { get; set; }
        public async Task OnGet(int id)
        {
            Bike = await _db.Bike.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var BikeFromDb = await _db.Bike.FindAsync(Bike.Id);
                BikeFromDb.Name = Bike.Name;
                BikeFromDb.Brand = Bike.Brand;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
