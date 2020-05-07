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
    // Copy from Create but make changes to OnGet and OnPost
    public class UpsertModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Game Game { get; set; }

        public UpsertModel(ApplicationDbContext db) {
            _db = db;
        }
        public async Task<IActionResult> OnGet(int? id) {
            Game = new Game();

            // create
            if (id == null) {
                return Page();
            }
            //update
            Game = await _db.Game.FirstOrDefaultAsync(u => u.Id == id);
            if(Game == null) {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPost() {
            if (ModelState.IsValid) {

                if (Game.Id == 0) {
                    _db.Game.Add(Game);
                }
                else {
                    // Use this if you want to edit all the properties
                    _db.Game.Update(Game);
                }

                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else {
                return RedirectToPage();
            }
        }
    }
}