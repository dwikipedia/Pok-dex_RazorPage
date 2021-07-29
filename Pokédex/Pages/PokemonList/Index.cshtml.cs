using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Pokédex.Pages.PokemonList
{
    public class IndexModel : PageModel
    {
        private readonly DataContext _context;

        public IndexModel(DataContext context) => _context = context;

        public IEnumerable<PokemonModel> Pokemons { get; set; }
        public async Task OnGet()
        {
            Pokemons = await _context.Pokemons.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var data = await _context.Pokemons.FindAsync(id);
            if (data == null)
                return NotFound();

            _context.Pokemons.Remove(data);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}