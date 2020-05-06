using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameListRazor.Pages.GameList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Game Game { get; set; }

        public CreateModel(ApplicationDbContext db) {
            _db = db;
        }
        public void OnGet()
        {
            // No need to pass the game object, it is automatic
        }

        public async Task<IActionResult> OnPost() {
            if (ModelState.IsValid) {
                await _db.Game.AddAsync(Game);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else {
                return Page();
            }
        }
    }
}