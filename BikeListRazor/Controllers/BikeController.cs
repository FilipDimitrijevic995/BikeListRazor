using BikeListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeListRazor.Controllers
{
    [Route("api/Bike")]
    public class BikeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BikeController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Bike.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var bikeFromDb = await _db.Bike.FirstOrDefaultAsync(u => u.Id == id);
            if (bikeFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _db.Bike.Remove(bikeFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful" });
        }
    }
}
