using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EF_Turismo.Data;
using EF_Turismo.Models;

namespace EF_Turismo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientModelsController : ControllerBase
    {
        private readonly EF_TurismoContext _context;

        public ClientModelsController(EF_TurismoContext context)
        {
            _context = context;
        }

        // GET: api/ClientModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientModel>>> GetClientModel()
        {
          if (_context.ClientModel == null)
          {
              return NotFound();
          }
            return await _context.ClientModel.ToListAsync();
        }

        // GET: api/ClientModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientModel>> GetClientModel(int id)
        {
          if (_context.ClientModel == null)
          {
              return NotFound();
          }
            var clientModel = await _context.ClientModel.FindAsync(id);

            if (clientModel == null)
            {
                return NotFound();
            }

            return clientModel;
        }

        // PUT: api/ClientModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientModel(int id, ClientModel clientModel)
        {
            if (id != clientModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(clientModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ClientModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClientModel>> PostClientModel(ClientModel clientModel)
        {
          if (_context.ClientModel == null)
          {
              return Problem("Entity set 'EF_TurismoContext.ClientModel'  is null.");
          }
            _context.ClientModel.Add(clientModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClientModel", new { id = clientModel.Id }, clientModel);
        }

        // DELETE: api/ClientModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientModel(int id)
        {
            if (_context.ClientModel == null)
            {
                return NotFound();
            }
            var clientModel = await _context.ClientModel.FindAsync(id);
            if (clientModel == null)
            {
                return NotFound();
            }

            _context.ClientModel.Remove(clientModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientModelExists(int id)
        {
            return (_context.ClientModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
