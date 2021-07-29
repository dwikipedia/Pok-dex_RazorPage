using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Pokédex.Controllers
{
    [Route("api/Pokemon")]
    [ApiController]
    public class PokemonController : Controller
    {
        private readonly DataContext _context;
        public PokemonController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _context.Pokemons.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _context.Pokemons.FirstOrDefaultAsync(a=>a.PokemonId == id);
            if (data == null)
                return Json(new { success = false, message = "Delete failed." });

            _context.Remove(data);
            await _context.SaveChangesAsync();
            return Json(new { success = true, message = "Deleted successfully" });
        }
    }
}
