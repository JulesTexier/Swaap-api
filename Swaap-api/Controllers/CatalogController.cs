using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swaap_api.Models;

namespace Swaap_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly SwaapContext _context;

        public CatalogController(SwaapContext context)
        {
            _context = context;
        }

        // GET: api/Catalog
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Catalog>>> GetCatalogs()
        {
          if (_context.Catalogs == null)
          {
              return NotFound();
          }
            return await _context.Catalogs.ToListAsync();
        }

        // GET: api/Catalog/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Catalog>> GetCatalog(long id)
        {
          if (_context.Catalogs == null)
          {
              return NotFound();
          }
            var catalog = await _context.Catalogs.FindAsync(id);

            if (catalog == null)
            {
                return NotFound();
            }

            return catalog;
        }

        // PUT: api/Catalog/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCatalog(long id, Catalog catalog)
        {
            if (id != catalog.Id)
            {
                return BadRequest();
            }

            _context.Entry(catalog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatalogExists(id))
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

        // POST: api/Catalog
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Catalog>> PostCatalog(Catalog catalog)
        {
          if (_context.Catalogs == null)
          {
              return Problem("Entity set 'SwaapContext.Catalogs'  is null.");
          }
            _context.Catalogs.Add(catalog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCatalog", new { id = catalog.Id }, catalog);
        }

        // DELETE: api/Catalog/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCatalog(long id)
        {
            if (_context.Catalogs == null)
            {
                return NotFound();
            }
            var catalog = await _context.Catalogs.FindAsync(id);
            if (catalog == null)
            {
                return NotFound();
            }

            _context.Catalogs.Remove(catalog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CatalogExists(long id)
        {
            return (_context.Catalogs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
