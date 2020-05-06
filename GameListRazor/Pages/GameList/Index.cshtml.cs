using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GameListRazor.Pages.GameList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IEnumerable<Game> Games { get; set; }

        public IndexModel(ApplicationDbContext db) {
            _db = db;
        }
        public async Task OnGet()
        {
            Games = await _db.Game.ToListAsync();
        }
    }
}