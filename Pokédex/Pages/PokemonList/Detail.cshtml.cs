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
    public class DetailModel : PageModel
    {
        private readonly DataContext _context;
        public DetailModel(DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PokemonModel Pokemon { get; set; }

        public List<SelectListItem> GenderList { get; set; }

        public async Task OnGet(int id)
        {
            GenderList = DropdownLists.DdlGender();
            Pokemon = await _context.Pokemons.FindAsync(id);

            foreach (var i in GenderList)
            {
                if (i.Value == Pokemon.Gender)
                    i.Selected = true;
            }
        }
    }
}