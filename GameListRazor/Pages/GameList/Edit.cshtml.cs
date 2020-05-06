using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameListRazor.Pages.GameList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Game Game { get; set; }

        public EditModel(ApplicationDbContext db) {
            _db = db;
        }
        public async Task OnGet(int id)
        {
            Game = await _db.Game.FindAsync(id);
        }
    }
}