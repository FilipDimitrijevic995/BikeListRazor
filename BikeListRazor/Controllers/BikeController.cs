using BikeListRazor.Model;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult GetAll()
        {
            return Json(new { data = _db.Bike.ToList() });
        }
    }
}
