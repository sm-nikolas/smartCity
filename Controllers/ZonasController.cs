using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartCityApi.Data;
using SmartCityApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartCityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZonasController : ControllerBase
    {
        private readonly SmartCityContext _context;

        public ZonasController(SmartCityContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Zona>>> GetZonas()
        {
            return await _context.Zonas.Include(z => z.Cidade).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Zona>> GetZona(int id)
        {
            var zona = await _context.Zonas.Include(z => z.Cidade).FirstOrDefaultAsync(z => z.Id == id);

            if (zona == null)
            {
                return NotFound();
            }

            return zona;
        }

        [HttpPost]
        public async Task<ActionResult<Zona>> PostZona(Zona zona)
        {
            _context.Zonas.Add(zona);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetZona), new { id = zona.Id }, zona);
        }
    }
}
