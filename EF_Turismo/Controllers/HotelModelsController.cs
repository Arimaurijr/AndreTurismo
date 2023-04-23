﻿using System;
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
    public class HotelModelsController : ControllerBase
    {
        private readonly EF_TurismoContext _context;

        public HotelModelsController(EF_TurismoContext context)
        {
            _context = context;
        }

        // GET: api/HotelModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelModel>>> GetHotelModel()
        {
          if (_context.HotelModel == null)
          {
              return NotFound();
          }
            return await _context.HotelModel.ToListAsync();
        }

        // GET: api/HotelModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelModel>> GetHotelModel(int id)
        {
          if (_context.HotelModel == null)
          {
              return NotFound();
          }
            var hotelModel = await _context.HotelModel.FindAsync(id);

            if (hotelModel == null)
            {
                return NotFound();
            }

            return hotelModel;
        }

        // PUT: api/HotelModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotelModel(int id, HotelModel hotelModel)
        {
            if (id != hotelModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(hotelModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelModelExists(id))
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

        // POST: api/HotelModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HotelModel>> PostHotelModel(HotelModel hotelModel)
        {
          if (_context.HotelModel == null)
          {
              return Problem("Entity set 'EF_TurismoContext.HotelModel'  is null.");
          }
            _context.HotelModel.Add(hotelModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHotelModel", new { id = hotelModel.Id }, hotelModel);
        }

        // DELETE: api/HotelModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelModel(int id)
        {
            if (_context.HotelModel == null)
            {
                return NotFound();
            }
            var hotelModel = await _context.HotelModel.FindAsync(id);
            if (hotelModel == null)
            {
                return NotFound();
            }

            _context.HotelModel.Remove(hotelModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HotelModelExists(int id)
        {
            return (_context.HotelModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}