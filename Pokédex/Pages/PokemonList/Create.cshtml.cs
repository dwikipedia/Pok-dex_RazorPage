using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AppContext;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Pokédex.Pages.PokemonList
{
    public class CreateModel : PageModel
    {
        private readonly DataContext _context;

        public CreateModel(DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PokemonModel Pokemon { get; set; }
        public List<SelectListItem> GenderList { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            GenderList = DropdownLists.DdlGender();

            Pokemon = new PokemonModel();
            if(id == null)
            {
                return Page();
            }
            Pokemon = await _context.Pokemons.FirstOrDefaultAsync(x => x.PokemonId == id);
            if (Pokemon == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                Pokemon.Gender = Request.Form["Gender"];

                if (Pokemon.PokemonId == 0)
                {
                    await _context.Pokemons.AddAsync(Pokemon);
                }
                else
                {
                    _context.Pokemons.Update(Pokemon);
                }
                if (Pokemon.ImageFormFile != null)
                    Pokemon.ImagePath = UploadFile.SaveAndGetFileName(Pokemon.ImageFormFile);

                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}