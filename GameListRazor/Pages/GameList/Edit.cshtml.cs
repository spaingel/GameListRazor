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

        public async Task<IActionResult> OnPost() {
            if (ModelState.IsValid) {
                var GameFromDb = await _db.Game.FindAsync(Game.Id);
                GameFromDb.Name = Game.Name;
                GameFromDb.GameSystem = Game.GameSystem;
                GameFromDb.Genre = Game.Genre;

                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else {
                return RedirectToPage();
            }
        }
    }
}