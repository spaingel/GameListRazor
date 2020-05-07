using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameListRazor.Model;
using Microsoft.AspNetCore.Mvc;

namespace GameListRazor.Controllers
{
    [Route("api/Game")]
    [ApiController]
    public class GameController : Controller
    {
        private readonly ApplicationDbContext _db;

        public GameController(ApplicationDbContext db) {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _db.Game.ToList() });
        }
    }
}