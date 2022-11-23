using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwaapApi.Models;

namespace Swaap_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogProductController : ControllerBase
    {
        private readonly SwaapContext _context;

        public CatalogProductController(SwaapContext context)
        {
            _context = context;
        }

        // GET: api/CatalogProduct
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatalogProduct>>> GetCatalogProducts()
        {
          if (_context.CatalogProducts == null)
          {
              return NotFound();
          }
            return await _context.CatalogProducts.ToListAsync();
        }

        // GET: api/CatalogProduct/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CatalogProduct>> GetCatalogProduct(long id)
        {
          if (_context.CatalogProducts == null)
          {
              return NotFound();
          }
            var catalogProduct = await _context.CatalogProducts.FindAsync(id);

            if (catalogProduct == null)
            {
                return NotFound();
            }

            return catalogProduct;
        }

        // PUT: api/CatalogProduct/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCatalogProduct(long id, CatalogProduct catalogProduct)
        {
            if (id != catalogProduct.Id)
            {
                return BadRequest();
            }

            _context.Entry(catalogProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatalogProductExists(id))
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

        // POST: api/CatalogProduct
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CatalogProduct>> PostCatalogProduct(CatalogProduct catalogProduct)
        {
          if (_context.CatalogProducts == null)
          {
              return Problem("Entity set 'SwaapContext.CatalogProducts'  is null.");
          }
            _context.CatalogProducts.Add(catalogProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCatalogProduct", new { id = catalogProduct.Id }, catalogProduct);
        }

        // DELETE: api/CatalogProduct/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCatalogProduct(long id)
        {
            if (_context.CatalogProducts == null)
            {
                return NotFound();
            }
            var catalogProduct = await _context.CatalogProducts.FindAsync(id);
            if (catalogProduct == null)
            {
                return NotFound();
            }

            _context.CatalogProducts.Remove(catalogProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CatalogProductExists(long id)
        {
            return (_context.CatalogProducts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
