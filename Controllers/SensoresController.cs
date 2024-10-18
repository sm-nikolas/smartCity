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
    public class SensoresController : ControllerBase
    {
        private readonly SmartCityContext _context;

        public SensoresController(SmartCityContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sensor>>> GetSensores()
        {
            return await _context.Sensores.Include(s => s.Zona).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sensor>> GetSensor(int id)
        {
            var sensor = await _context.Sensores.Include(s => s.Zona).FirstOrDefaultAsync(s => s.Id == id);

            if (sensor == null)
            {
                return NotFound();
            }

            return sensor;
        }

        [HttpPost]
        public async Task<ActionResult<Sensor>> PostSensor(Sensor sensor)
        {
            _context.Sensores.Add(sensor);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSensor), new { id = sensor.Id }, sensor);
        }
    }
}
