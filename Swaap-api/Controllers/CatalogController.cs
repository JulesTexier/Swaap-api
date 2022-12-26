using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<ActionResult<IEnumerable<CatalogItemDTO>>> GetCatalogItems()
        {

            return await _context.CatalogItems
                .Select(x => ItemToDTO(x))
                .ToListAsync();
        }

        // GET: api/Catalog/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CatalogItemDTO>> GetCatalogItem(int? id)
        {
            var catalogItem = await _context.CatalogItems.FindAsync(id);

            if (catalogItem == null)
            {
                return NotFound();
            }

            return ItemToDTO(catalogItem);
        }

        // PUT: api/Catalog/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCatalogItem(int? id, CatalogItemDTO catalogDTO)
        {
            if (id != catalogDTO.Id)
            {
                return BadRequest();
            }

            var catalogItem = await _context.CatalogItems.FindAsync(id);

            if (catalogItem == null)
            {
                return NotFound();
            }

            catalogItem.Name = catalogDTO.Name;
            catalogItem.Id = catalogDTO.Id;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!CatalogItemExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }


        // POST: api/Catalog
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CatalogItemDTO>> PostCatalogItem(CatalogItemDTO catalogDTO)
        {

            var catalogItem = new CatalogItem
            {
                Name = catalogDTO.Name,
                Id = catalogDTO.Id
            };

            _context.CatalogItems.Add(catalogItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetCatalogItem),
                new { id = catalogItem.Id },
                ItemToDTO(catalogItem));
            ;
        }

        // DELETE: api/Catalog/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCatalogItem(int? id)
        {
            var catalogItem = await _context.CatalogItems.FindAsync(id);

            if (catalogItem == null)
            {
                return NotFound();
            }

            _context.CatalogItems.Remove(catalogItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CatalogItemExists(int? id)
        {
            return (_context.CatalogItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private static CatalogItemDTO ItemToDTO(CatalogItem catalogItem) =>
            new CatalogItemDTO
            {
                Id = catalogItem.Id,
                Name = catalogItem.Name

            };
    }
}
