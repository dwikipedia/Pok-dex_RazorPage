using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Pokédex.Pages
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var pokemons = _context.Pokemons
                .AsNoTracking()
                .ToList();

            return Ok(pokemons);
        }
    }
}
